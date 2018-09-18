namespace PhotoShare.Client.Core.Dtos
{
    using PhotoShare.Client.Core.Validation;

    using System;

    public class LoginUserDto
    {
        public string Username { get; set; }
        [Password(4, 20)]
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastTimeLoggedIn { get; set; }
    }
}