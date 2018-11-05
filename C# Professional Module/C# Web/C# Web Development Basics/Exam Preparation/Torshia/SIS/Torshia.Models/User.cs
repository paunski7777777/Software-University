namespace Torshia.Models
{
    using System.ComponentModel.DataAnnotations;

    using Torshia.Models.Enums;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Role { get; set; }
    }
}