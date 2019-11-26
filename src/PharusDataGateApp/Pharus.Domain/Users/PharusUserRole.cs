namespace Pharus.Domain
{
    using Microsoft.AspNetCore.Identity;

    using Pharus.Domain.Users;

    public class PharusUserRole : IdentityUserRole<string>
    {
        public virtual PharusUser User { get; set; }

        public virtual PharusRole Role { get; set; }
    }
}
