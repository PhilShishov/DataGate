namespace Pharus.Domain.Models.Users
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class PharusRole : IdentityRole
    {
        public ICollection<PharusUserRole> UserRoles { get; set; }
    }
}
