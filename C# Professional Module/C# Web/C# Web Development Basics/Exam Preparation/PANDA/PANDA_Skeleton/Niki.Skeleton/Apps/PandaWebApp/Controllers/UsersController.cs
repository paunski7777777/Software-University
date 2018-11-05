namespace PandaWebApp.Controllers
{
    using PandaWebApp.Models;
    using PandaWebApp.Models.Enums;
    using PandaWebApp.ViewModels.Users;

    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System;
    using System.Linq;

    public class UsersController : BaseController
    {
        public IHttpResponse Login()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(LoginViewModel model)
        {

            var user = this.db.Users.FirstOrDefault(u => u.Username == model.Username
                                                      && u.Password == model.Password);

            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid username or password.");
            }

            var mvcUser = new MvcUserInfo
            {
                Username = user.Username,
                Role = user.Role.ToString()
            };

            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestErrorWithView("Passwords do not match.");
            }


            var role = Role.User;

            if (!this.db.Users.Any())
            {
                role = Role.Admin;
            }

            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Role = role
            };

            this.db.Users.Add(user);

            try
            {
                this.db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.BadRequestErrorWithView(e.Message);
            }

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }
    }
}