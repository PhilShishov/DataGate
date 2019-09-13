
namespace Pharus.Domain
{
    using Microsoft.AspNetCore.Identity;

    public class PharusUser : IdentityUser
    {
        public PharusUserRole UserRole { get; set; }
    }
}
