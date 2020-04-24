namespace DataGate.Domain.Models.Users
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class PharusUser : IdentityUser
    {
        public DateTimeOffset? LastLoginTime { get; set; }

        public ICollection<PharusUserRole> UserRoles { get; set; }
    }
}
