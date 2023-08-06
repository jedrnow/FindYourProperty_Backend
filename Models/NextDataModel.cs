using Newtonsoft.Json;

namespace PropertyScraper.Models
{
    public class NextDataModel
    {
        public class Ad
        {
            public int id { get; set; }
            public string market { get; set; }
            public List<object> services { get; set; }
            public string publicId { get; set; }
            public string slug { get; set; }
            public string advertiserType { get; set; }
            public string advertType { get; set; }
            public string source { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime modifiedAt { get; set; }
            public string description { get; set; }
            public int developmentId { get; set; }
            public string developmentTitle { get; set; }
            public string developmentUrl { get; set; }
            public bool exclusiveOffer { get; set; }
            public string externalId { get; set; }
            public List<string> features { get; set; }
            public List<FeaturesByCategory> featuresByCategory { get; set; }
            public List<object> featuresWithoutCategory { get; set; }
            public OpenDay openDay { get; set; }
            public string referenceId { get; set; }
            public Target target { get; set; }
            public string title { get; set; }
            public List<TopInformation> topInformation { get; set; }
            public List<AdditionalInformation> additionalInformation { get; set; }
            public string url { get; set; }
            public string status { get; set; }
            public AdCategory adCategory { get; set; }
            public Category category { get; set; }
            public List<Characteristic> characteristics { get; set; }
            public List<Image> images { get; set; }
            public Links links { get; set; }
            public Location location { get; set; }
            public Property property { get; set; }
            public Owner owner { get; set; }
            public Agency agency { get; set; }
            public Seo seo { get; set; }
            public List<Breadcrumb> breadcrumbs { get; set; }
            public List<UserAdvert> userAdverts { get; set; }
            public PaginatedUnits paginatedUnits { get; set; }
            public object specialOffer { get; set; }
            public string __typename { get; set; }
            public ContactDetails contactDetails { get; set; }
        }

        public class AdCategory
        {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string __typename { get; set; }
        }

        public class AdditionalInformation
        {
            public string label { get; set; }
            public List<string> values { get; set; }
            public string unit { get; set; }
            public string __typename { get; set; }
        }

        public class Address
        {
            public Street street { get; set; }
            public object subdistrict { get; set; }
            public District district { get; set; }
            public City city { get; set; }
            public object municipality { get; set; }
            public County county { get; set; }
            public Province province { get; set; }
            public object postalCode { get; set; }
            public string __typename { get; set; }
        }

        public class AdTrackingData
        {
            public string touch_point_page { get; set; }
            public double lat { get; set; }
            public double @long { get; set; }
            public int ad_photo { get; set; }
            public string price_currency { get; set; }
            public int cat_l1_id { get; set; }
            public string cat_l1_name { get; set; }
            public object special_offer_type { get; set; }
            public string ad_id { get; set; }
            public int ad_price { get; set; }
            public string business { get; set; }
            public string city_id { get; set; }
            public string city_name { get; set; }
            public string market { get; set; }
            public string poster_type { get; set; }
            public object surface { get; set; }
            public string region_id { get; set; }
            public string region_name { get; set; }
            public string subregion_id { get; set; }
            public string seller_id { get; set; }
            public string obido_advert { get; set; }
        }

        public class Agency
        {
            public int id { get; set; }
            public string name { get; set; }
            public string licenseNumber { get; set; }
            public string type { get; set; }
            public List<string> phones { get; set; }
            public string address { get; set; }
            public string imageUrl { get; set; }
            public string url { get; set; }
            public string leaderYear { get; set; }
            public bool brandingVisible { get; set; }
            public List<string> enabledFeatures { get; set; }
            public string __typename { get; set; }
        }

        public class Area
        {
            public int value { get; set; }
            public string unit { get; set; }
            public string __typename { get; set; }
        }

        public class Breadcrumb
        {
            public string label { get; set; }
            public string locative { get; set; }
            public string url { get; set; }
            public string __typename { get; set; }
        }

        public class BuildingProperties
        {
            public int year { get; set; }
            public string type { get; set; }
            public object material { get; set; }
            public List<string> windows { get; set; }
            public string heating { get; set; }
            public int numberOfFloors { get; set; }
            public List<string> conveniences { get; set; }
            public List<string> security { get; set; }
            public string __typename { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public List<Name> name { get; set; }
            public string __typename { get; set; }
        }

        public class Characteristic
        {
            public string key { get; set; }
            public string value { get; set; }
            public string label { get; set; }
            public string localizedValue { get; set; }
            public string currency { get; set; }
            public string suffix { get; set; }
            public string __typename { get; set; }
        }

        public class City
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string __typename { get; set; }
        }

        public class ContactDetails
        {
            public string name { get; set; }
            public string type { get; set; }
            public List<string> phones { get; set; }
            public string imageUrl { get; set; }
        }

        public class Coordinates
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string __typename { get; set; }
        }

        public class County
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string __typename { get; set; }
        }

        public class District
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string __typename { get; set; }
        }

        public class Experiments
        {
            [JsonProperty("EUADS-4306")]
            public string EUADS4306 { get; set; }

            [JsonProperty("REPM-844")]
            public object REPM844 { get; set; }

            [JsonProperty("SFS-572")]
            public string SFS572 { get; set; }

            [JsonProperty("SMR-2326")]
            public object SMR2326 { get; set; }

            [JsonProperty("SEE-1767")]
            public string SEE1767 { get; set; }

            [JsonProperty("SEE-1753")]
            public string SEE1753 { get; set; }

            [JsonProperty("SEE-1754")]
            public object SEE1754 { get; set; }

            [JsonProperty("SMR-1912")]
            public string SMR1912 { get; set; }
        }

        public class FeatureFlags
        {
            public bool isAdAvmModuleEnabled { get; set; }
            public bool isAdFinanceBannerEnabled { get; set; }
            public bool isAdFinanceLinkEnabled { get; set; }
            public bool isAdMortgageSimulatorEnabled { get; set; }
            public bool isAgentsSubaccountsEnabled { get; set; }
            public bool isBulkSchedulingEnabled { get; set; }
            public bool isFeaturedDevelopmentVASEnabled { get; set; }
            public bool isListingRentPriceEnabled { get; set; }
            public bool isMapEnabled { get; set; }
            public bool isNewApartmentsForSalePostingFormEnabled { get; set; }
            public bool isNewPromotePageEnabled { get; set; }
            public bool isOldSaveSearchQueryEnabled { get; set; }
            public bool shouldRolloutLocationService { get; set; }
            public bool isOlxAdvertPromotionEnabled { get; set; }
            public bool isOtodomAnalyticsEnabled { get; set; }
            public bool isProjectREDEnabled { get; set; }
            public bool isPushNotificationServiceWorkerEnabled { get; set; }
            public bool isPushNotificationsToggleEnabled { get; set; }
            public bool isSavedSearchFrequencyChangeEnabled { get; set; }
            public bool isVasRecommendationsEnabled { get; set; }
            public bool isVasSchedulingEnabled { get; set; }
            public bool shouldUseNewInformation { get; set; }
            public bool shouldUseNewProjectPage { get; set; }
            public bool isFinanceCheckboxEnabled { get; set; }
            public bool isObservedAdsPageEnabled { get; set; }
            public bool isNewAskAboutPriceEnabled { get; set; }
            public bool isHomepageVasConverted { get; set; }
            public bool isDevelopersPricingCardsDesignEnabled { get; set; }
            public bool isUnifiedBusinessInvoicesPageActive { get; set; }
            public bool isRegularMyAccountAdsPageEnabled { get; set; }
            public bool isBikPromotionEnabled { get; set; }
            public bool isStudioFlatCategoryEnabled { get; set; }
            public bool isRegularRoomCategoryMigratedToNMF { get; set; }
            public bool isSpecialOfferForUnitsExperimentEnabled { get; set; }
            public bool isRegularExtendedBundlesEnabled { get; set; }
            public bool isNoOfRoomsFilterEnabled { get; set; }
            public bool isStaticInternalLinkingSectionEnabled { get; set; }
            public bool isRegularOlxVasesEnabled { get; set; }
            public bool isSpecialOfferEnabled { get; set; }
            public bool isBulkOlxPromotionEnabled { get; set; }
            public bool isRegularVasRecommendationsEnabled { get; set; }
            public bool isSeoAdsDescriptionEnabled { get; set; }
            public string __typename { get; set; }
        }

        public class FeaturesByCategory
        {
            public string label { get; set; }
            public List<string> values { get; set; }
            public string __typename { get; set; }
        }

        public class Image
        {
            public string thumbnail { get; set; }
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
            public string __typename { get; set; }
        }

        public class Links
        {
            public string localPlanUrl { get; set; }
            public string videoUrl { get; set; }
            public string view3dUrl { get; set; }
            public string walkaroundUrl { get; set; }
            public string __typename { get; set; }
        }

        public class Location
        {
            public object id { get; set; }
            public Coordinates coordinates { get; set; }
            public MapDetails mapDetails { get; set; }
            public Address address { get; set; }
            public ReverseGeocoding reverseGeocoding { get; set; }
            public string __typename { get; set; }
        }

        public class Location2
        {
            public string id { get; set; }
            public string locationLevel { get; set; }
            public string name { get; set; }
            public string fullName { get; set; }
            public List<string> fullNameItems { get; set; }
            public List<string> parentIds { get; set; }
            public string __typename { get; set; }
        }

        public class MapDetails
        {
            public int radius { get; set; }
            public int zoom { get; set; }
            public string __typename { get; set; }
        }

        public class Name
        {
            public string locale { get; set; }
            public string value { get; set; }
            public string __typename { get; set; }
        }

        public class OpenDay
        {
            public object date { get; set; }
            public object timeFrom { get; set; }
            public object timeTo { get; set; }
            public string __typename { get; set; }
        }

        public class Owner
        {
            public int id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public List<string> phones { get; set; }
            public string imageUrl { get; set; }
            public List<object> contacts { get; set; }
            public string __typename { get; set; }
        }

        public class PageProps
        {
            public string lang { get; set; }
            public string _sentryTraceData { get; set; }
            public string _sentryBaggage { get; set; }
            public Experiments experiments { get; set; }
            public string id { get; set; }
            public Ad ad { get; set; }
            public string relativeUrl { get; set; }
            public AdTrackingData adTrackingData { get; set; }
            public object referer { get; set; }
            public object currentUser { get; set; }
            public FeatureFlags featureFlags { get; set; }
            public string laquesisResult { get; set; }
            public string userSessionId { get; set; }
            public object unconfirmedUserAuthToken { get; set; }
            public bool isBotDetected { get; set; }
        }

        public class PaginatedUnits
        {
            public object items { get; set; }
            public object isPriceHidden { get; set; }
            public object pagination { get; set; }
            public object facets { get; set; }
            public string __typename { get; set; }
        }

        public class Price
        {
            public string value { get; set; }
            public string unit { get; set; }
            public string __typename { get; set; }
        }

        public class Properties
        {
            public List<object> equipment { get; set; }
            public List<string> areas { get; set; }
            public string floor { get; set; }
            public string kitchen { get; set; }
            public List<object> parking { get; set; }
            public int numberOfRooms { get; set; }
            public List<object> rooms { get; set; }
            public object type { get; set; }
            public List<object> windowsOrientation { get; set; }
            public string __typename { get; set; }
        }

        public class Property
        {
            public object id { get; set; }
            public string type { get; set; }
            public Rent rent { get; set; }
            public List<object> costs { get; set; }
            public object condition { get; set; }
            public Properties properties { get; set; }
            public BuildingProperties buildingProperties { get; set; }
            public string ownership { get; set; }
            public Area area { get; set; }
            public string __typename { get; set; }
        }

        public class Props
        {
            public PageProps pageProps { get; set; }
            public bool __N_SSP { get; set; }
        }

        public class Province
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string __typename { get; set; }
        }

        public class Query
        {
            public string id { get; set; }
        }

        public class Rent
        {
            public int value { get; set; }
            public string currency { get; set; }
            public string __typename { get; set; }
        }

        public class ReverseGeocoding
        {
            public List<Location> locations { get; set; }
            public string __typename { get; set; }
        }

        public class Root
        {
            public Props props { get; set; }
            public string page { get; set; }
            public Query query { get; set; }
            public string buildId { get; set; }
            public string assetPrefix { get; set; }
            public RuntimeConfig runtimeConfig { get; set; }
            public bool isFallback { get; set; }
            public List<int> dynamicIds { get; set; }
            public bool gssp { get; set; }
            public bool customServer { get; set; }
            public bool appGip { get; set; }
            public List<object> scriptLoader { get; set; }
        }

        public class RuntimeConfig
        {
            public string appleCognitoLoginUrl { get; set; }
            public string env { get; set; }
            public string fbCognitoLoginUrl { get; set; }
            public string fileUploadServiceUrl { get; set; }
            public string googleApiKey { get; set; }
            public bool isOneTrustAutoDeleteEnabled { get; set; }
            public bool isOneTrustEnabled { get; set; }
            public bool isSentryEnabled { get; set; }
            public string googleCognitoLoginUrl { get; set; }
            public string oneTrustSiteId { get; set; }
            public string ninjaEnvironment { get; set; }
            public string nodeEnv { get; set; }
            public string pushNotificationPublicKey { get; set; }
            public string sentryDsn { get; set; }
            public string sentryEnvironment { get; set; }
            public double sentrySampleRateClient { get; set; }
            public int sentryTracesSampleRateClient { get; set; }
            public string staticAssetsPrefix { get; set; }
        }

        public class Seo
        {
            public string title { get; set; }
            public string description { get; set; }
            public string __typename { get; set; }
        }

        public class Street
        {
            public string id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string number { get; set; }
            public string __typename { get; set; }
        }

        public class Target
        {
            public string Area { get; set; }
            public List<object> AreaRange { get; set; }
            public string Build_year { get; set; }
            public string Building_floors_num { get; set; }
            public List<string> Building_ownership { get; set; }
            public List<string> Building_type { get; set; }
            public string City { get; set; }
            public string City_id { get; set; }
            public string Country { get; set; }
            public List<string> Extras_types { get; set; }
            public List<string> Floor_no { get; set; }
            public List<string> Heating { get; set; }
            public string Id { get; set; }
            public string MarketType { get; set; }
            public List<string> Media_types { get; set; }
            public string ObidoAdvert { get; set; }
            public string OfferType { get; set; }
            public string Photo { get; set; }
            public int Price { get; set; }
            public List<string> PriceRange { get; set; }
            public int Price_per_m { get; set; }
            public string ProperType { get; set; }
            public string Province { get; set; }
            public string RegularUser { get; set; }
            public int Rent { get; set; }
            public List<string> Rooms_num { get; set; }
            public List<string> Security_types { get; set; }
            public string Subregion { get; set; }
            public string Title { get; set; }
            public List<string> Windows_type { get; set; }
            public string categoryId { get; set; }
            public string env { get; set; }
            public string hidePrice { get; set; }
            public string seller_id { get; set; }
            public string user_type { get; set; }
        }

        public class TopInformation
        {
            public string label { get; set; }
            public List<string> values { get; set; }
            public string unit { get; set; }
            public string __typename { get; set; }
        }

        public class UserAdvert
        {
            public string url { get; set; }
            public string image { get; set; }
            public string roomsNum { get; set; }
            public int pricePerM { get; set; }
            public Price price { get; set; }
            public string netArea { get; set; }
            public string title { get; set; }
            public string __typename { get; set; }
        }


    }
}
