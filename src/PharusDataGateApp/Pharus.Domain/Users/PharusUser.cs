
namespace Pharus.Domain
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class PharusUser : IdentityUser
    {
        public DateTimeOffset? LastLoginTime { get; set; }
        public PharusUserRole UserRole { get; set; }
    }
}
