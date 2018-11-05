namespace PandaWebApp.ViewModels.Users
{
    public class RegisterViewModel : LoginViewModel
    {
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}