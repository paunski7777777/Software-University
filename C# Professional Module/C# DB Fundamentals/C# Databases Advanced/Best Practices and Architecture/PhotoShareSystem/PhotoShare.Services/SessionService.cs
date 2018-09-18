namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    using System.Linq;

    public class SessionService : ISessionService
    {
        private readonly PhotoShareContext context;
        public User User { get; set; }

        public SessionService(PhotoShareContext context, User user)
        {
            this.context = context;
            this.User = user;
        }

        public void Login(string username, string password)
        {
            this.User = this.context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void Loguot()
        {
            this.User = null;
        }
        
        public bool IsAuthenticated() => this.User != null;
    }
}