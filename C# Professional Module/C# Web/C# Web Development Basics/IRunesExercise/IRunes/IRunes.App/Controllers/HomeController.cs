namespace IRunes.App.Controllers
{
    using IRunes.App.ViewModels;

    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Controllers;

    using System.Collections.Generic;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var loginViewModel = new LoginViewModel
            {
                Username = "Whatever",
                Password = "DoubleWhatever",
                NestedViewModels = new List<NestedViewModel>
                {
                    new NestedViewModel(){Count = 5, NestingLevel = 1},
                    new NestedViewModel(){Count = 500, NestingLevel = 200},
                },
            };

            this.ViewModel.Data["LoginViewModel"] = loginViewModel;

            return this.View();
        }
    }
}