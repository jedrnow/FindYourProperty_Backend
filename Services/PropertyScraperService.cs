using HtmlAgilityPack;
using PropertyScraper.Data;
using PropertyScraper.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace PropertyScraper.Services
{
    public class PropertyScraperService
    {
        private readonly HttpClient _httpClient;
        private readonly PropertyRepository _propertyRepository;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public PropertyScraperService(PropertyScraperDbContext dbContext, IWebDriver driver)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
            _propertyRepository = new PropertyRepository(dbContext);
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }
        public async Task<bool> ScrapAndSaveProperties(string url, string city, bool triggerFullScrap)
        {
            List<string> hrefAttributes = await ScrapAllAds(url);
            bool werePropertiesSavedProperly = await ScrapRangeByHref(hrefAttributes, city,triggerFullScrap);

            return werePropertiesSavedProperly;
        }
        public async Task<List<string>> ScrapAllAds(string url)
        {
            List<string> hrefAttributes = new();
            try
            {
                string currentPageUrl = url;
                _driver.Navigate().GoToUrl(currentPageUrl);
                _driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();

                for (int pageNumber=1;pageNumber<100;pageNumber++)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    bool waited = _wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                    if (waited)
                    {
                        string htmlString = _driver.PageSource;
                        HtmlDocument doc = new();
                        doc.LoadHtml(htmlString);

                        var anchorElements = doc.DocumentNode.SelectNodes("//a[@data-cy='listing-item-link']");
                        if (anchorElements == null || !anchorElements.Any())
                        {
                            Console.WriteLine("No more elements found.");
                            break;
                        }
                        hrefAttributes.AddRange(anchorElements.Select(anchor => anchor.GetAttributeValue("href", "")));

                        HtmlNode nextPageButton = doc.DocumentNode.SelectSingleNode("//nav[@data-cy='pagination']//button[@data-cy='pagination.next-page']");
                        bool isNextPageDisabled = nextPageButton?.Attributes["disabled"] != null;
                        if (isNextPageDisabled)
                        {
                            // Stop scraping if the "next page" button is disabled
                            break;
                        }
                        else
                        {
                            currentPageUrl = currentPageUrl.Replace($"&page={pageNumber}&", $"&page={pageNumber + 1}&");
                            _driver.Navigate().GoToUrl(currentPageUrl);
                        }
                    }
                }
                _driver.Quit();
                return hrefAttributes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                _driver.Quit();
                return hrefAttributes;
            }
        }

        public async Task<bool> ScrapRangeByHref(List<string> hrefAttributes, string city, bool triggerFullScrap)
        {
            if (triggerFullScrap)
            {
                await _propertyRepository.DeleteAllByCity(city);
                await _propertyRepository.SaveChangesAsync();
            }

            int scrapedPropertiesCount = 0;
            foreach (string hrefAttribute in hrefAttributes)
            {
                Property existingProperty = await _propertyRepository.GetByHref(hrefAttribute);
                if (existingProperty != null)
                {
                    Console.WriteLine($"Property already in database: id = {existingProperty.Id}");
                    continue;
                }
                else
                {
                    string adUrl = "https://www.otodom.pl/" + hrefAttribute;
                    try
                    {
                        string htmlString = await _httpClient.GetStringAsync(adUrl);
                        HtmlDocument adDoc = new();
                        adDoc.LoadHtml(htmlString);

                        string allDataString = adDoc.DocumentNode.SelectSingleNode("/html//script[@id='__NEXT_DATA__']")?.InnerText;
                        JObject jsonObject = JObject.Parse(allDataString);
                        JObject props = (JObject)jsonObject["props"];
                        JObject pageProps = (JObject)props["pageProps"];
                        JObject ad = (JObject)pageProps["ad"];
                        JArray imagesArray = (JArray)ad["images"];

                        List<NextDataModel.Image> imagesList = imagesArray.ToObject<List<NextDataModel.Image>>();

                        string title = adDoc.DocumentNode.SelectSingleNode("//h1[@data-cy='adPageAdTitle']")?.InnerText;
                        string location = adDoc.DocumentNode.SelectSingleNode("//header/div/a[@aria-label='Adres']")?.InnerText;
                        string price = adDoc.DocumentNode.SelectSingleNode("//*[@data-cy='adPageHeaderPrice']")?.InnerText.Replace(" ", "").Replace("zł", "");
                        string pricePerMeter = adDoc.DocumentNode.SelectSingleNode("//*[@aria-label='Cena za metr kwadratowy']")?.InnerText.Replace(" ", "").Replace("zł/m²", "");
                        string description = adDoc.DocumentNode.SelectSingleNode("//*[@data-cy='adPageAdDescription']")?.InnerText;


                        Dictionary<string, string> parameters = new();
                        var parameterKeys = adDoc.DocumentNode.SelectNodes("//*[@data-testid='ad.top-information.table']/div/div/div[1]");
                        var parameterValues = adDoc.DocumentNode.SelectNodes("//*[@data-testid='ad.top-information.table']/div/div/div[last()]");

                        if (parameterKeys != null && parameterValues != null)
                        {
                            for (int i = 0; i < parameterKeys.Count; i++)
                            {
                                var key = parameterKeys[i].InnerText;
                                var value = parameterValues[i].InnerText;
                                if (!value.Contains("Zapytaj"))
                                {
                                    parameters.Add(key, value);
                                }
                            }
                        }

                        Property property = new()
                        {
                            Title = title,
                            Location = location,
                            City=city,
                            Href = hrefAttribute,
                            Url = adUrl,
                            Price = Int32.Parse(price),
                            PricePerMeter = Int32.Parse(pricePerMeter),
                            Description = description,
                            DateScraped = DateTime.UtcNow
                        };

                        List<PropertyImage> imagesMapped = new();
 
                            foreach (var image in imagesList)
                            {
                                imagesMapped.Add(new PropertyImage()
                                {
                                    thumbnail = image.thumbnail,
                                    large = image.large,
                                    medium = image.medium,
                                    small = image.small,
                                    __typename = image.__typename,
                                    Property = property
                                });
                            }
                        property.PropertyImages = imagesMapped;

                        Property readyToSaveProperty = await SortParameters(property, parameters);
                        bool wasPropertyAdded = await _propertyRepository.Add(readyToSaveProperty);
                        if (!wasPropertyAdded)
                        {
                            Console.WriteLine($"Error while adding property: {readyToSaveProperty.Url}");
                        }
                        else
                        {
                            scrapedPropertiesCount += 1;
                            Console.WriteLine($"Successfully added property: {{id = {readyToSaveProperty.Id}, title = {readyToSaveProperty.Title}}}");
                        }

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error while scraping ad url: {adUrl}");
                        Console.WriteLine($"Message: {ex.Message}");
                    }
                }
            }

            return (await _propertyRepository.SaveChangesAsync()!=0);
        }

        public async Task<Property> SortParameters(Property property, Dictionary<string, string> parameters)
        {
            string surface, numberOfRooms, rent, heating;

            parameters.TryGetValue("Powierzchnia", out surface);
            parameters.TryGetValue("Liczba pokoi", out numberOfRooms);
            parameters.TryGetValue("Czynsz", out rent);
            parameters.TryGetValue("Ogrzewanie", out heating);

            property.Surface = surface;
            property.NumberOfRooms = numberOfRooms;
            property.Rent = rent;
            property.Heating = heating;

            return property;
        }

        public async Task<List<PropertyItemDto>> GetPropertiesByCity(string city)
        {
            IQueryable<Property> properties = await _propertyRepository.GetAllByCity(city);
            List<PropertyItemDto> result = await properties.Select(property => new PropertyItemDto()
            {
                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                MainImage = property.PropertyImages.FirstOrDefault(),
                City = property.City,
                Price = property.Price,
                PricePerMeter = property.PricePerMeter,
                Location = property.Location,
                Url = property.Url,
                Surface = property.Surface,
                Rent = property.Rent,
                Heating = property.Heating,
                NumberOfRooms = property.NumberOfRooms
            }).ToListAsync();

            return result;
        }
    }
}
