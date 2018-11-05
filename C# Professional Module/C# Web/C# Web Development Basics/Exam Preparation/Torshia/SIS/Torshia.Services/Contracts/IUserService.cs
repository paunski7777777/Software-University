using Torshia.Models;

namespace Torshia.Services.Contracts
{
    public interface IUserService
    {
        void RegisterUser(string username, string password, string email);
        bool UserExistsByUsernameAndPassword(string username, string password);
        User GetByUsernameAndPassword(string username, string password);
        User GetNyUsermame(string username);
    }
}