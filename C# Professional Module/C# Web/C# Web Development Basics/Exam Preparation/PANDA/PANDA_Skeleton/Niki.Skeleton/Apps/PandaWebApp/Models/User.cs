namespace PandaWebApp.Models
{
    using PandaWebApp.Models.Enums;

    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }
    }
}