namespace Pharus.Domain.Models.Users
{
    using Microsoft.AspNetCore.Identity;

    public class PharusUserRole : IdentityUserRole<string>
    {
        public virtual PharusUser User { get; set; }

        public virtual PharusRole Role { get; set; }
    }
}
