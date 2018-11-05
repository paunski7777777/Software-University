namespace Torshia.Services
{
    using Torshia.Data;
    using Torshia.Services.Contracts;
    using Torshia.Models;
    using Torshia.Models.Enums;

    using System.Linq;

    public class UserService : IUserService
    {
        private readonly TorshiaContext db;

        public UserService(TorshiaContext db)
        {
            this.db = db;
        }

        public User GetByUsernameAndPassword(string username, string password)
            => this.db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        public User GetNyUsermame(string username) => this.db.Users.FirstOrDefault(u => u.Username == username);

        public void RegisterUser(string username, string password, string email)
        {
            var role = this.db.Users.Any() ? Role.User : Role.Admin;

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool UserExistsByUsernameAndPassword(string username, string password)
            => this.db.Users.Any(u => u.Username == username && u.Password == password);
    }
}
