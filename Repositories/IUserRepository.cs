namespace PropertyScraper.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckUserAlreadyExists(string username, string email);
    }
}