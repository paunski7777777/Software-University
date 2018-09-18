using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface ISessionService
    {
        User User { get; }
        void Login(string username, string password);
        void Loguot();
        bool IsAuthenticated();
    }
}