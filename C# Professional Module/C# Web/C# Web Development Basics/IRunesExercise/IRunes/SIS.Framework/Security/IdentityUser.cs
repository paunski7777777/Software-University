namespace SIS.Framework.Security
{
    using System;

    using SIS.Framework.Security.Base;

    public class IdentityUser : IdentityUserT<string>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}