namespace Services
{
    using IRunes.Data;

    using Services.Contracts;

    using System.Linq;

    public class UsersService : IUsersService
    {
        private readonly IRunesContext context;
        private readonly IHashService hashService;

        public UsersService(IRunesContext context, IHashService hashService)
        {
            this.context = context;
            this.hashService = hashService;
        }

        public bool ExistsByUsernameAndPassword(string username, string password)
        {
            var hashedPassword = this.hashService.Hash(password);

            var userExists = this.context.Users.Any(u => u.Username == username && u.Password == hashedPassword);

            return userExists;
        }
    }
}