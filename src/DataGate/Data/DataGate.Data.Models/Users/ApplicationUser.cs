// ReSharper disable VirtualMemberCallInConstructor
namespace DataGate.Data.Models.Users
{
    using System;
    using System.Collections.Generic;

    using DataGate.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private readonly DateTimeOffset now = DateTimeOffset.UtcNow;

        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserRoles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.LastLoginTime = TimeZoneInfo.ConvertTime(this.now, TimeZoneInfo.Local);
        }

        public DateTimeOffset LastLoginTime { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
