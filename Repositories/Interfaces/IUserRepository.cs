using Login.Models;

namespace Login.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserAsync(string email, string password);
    }
}
