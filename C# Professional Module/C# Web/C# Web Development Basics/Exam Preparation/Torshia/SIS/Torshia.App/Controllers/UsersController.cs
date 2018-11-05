namespace Torshia.App.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Method;
    using SIS.Framework.Security;
    using System.Collections.Generic;
    using Torshia.App.Controllers.Base;
    using Torshia.App.ViewModels;
    using Torshia.Services.Contracts;

    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var userExists = this.userService.UserExistsByUsernameAndPassword(model.Username, model.Password);

            if (!userExists)
            {
                this.RedirectToAction("/users/register");
            }

            var user = this.userService.GetByUsernameAndPassword(model.Username, model.Password);

            this.SignIn(new IdentityUser
            {
                Username = model.Username,
                Roles = new List<string>
                {
                    user.Role.ToString()
                }
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            this.userService.RegisterUser(model.Username, model.Password, model.Email);

            this.SignIn(new IdentityUser()
            {
                Username = model.Username,
                Email = model.Email
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToAction("/");
        }
    }
}