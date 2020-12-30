// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Models.Users
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using DataGate.Data.Common.Models;
    using DataGate.Data.Models.Columns;

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
            this.UserFundColumns = new HashSet<UserFundColumn>();
            this.UserSubFundColumns = new HashSet<UserSubFundColumn>();
            this.UserShareClassColumns = new HashSet<UserShareClassColumn>();
            this.UserFundSubFundsColumns = new HashSet<UserFundSubFundsColumn>();
            this.UserSubFundShareClassesColumns = new HashSet<UserSubFundShareClassesColumn>();
            this.RecentlyViewedItems = new HashSet<RecentlyViewed>();
            this.UserNotifications = new HashSet<UserNotification>();
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

        public virtual ICollection<UserFundColumn> UserFundColumns { get; set; }
               
        public virtual ICollection<UserSubFundColumn> UserSubFundColumns { get; set; }
               
        public virtual ICollection<UserShareClassColumn> UserShareClassColumns { get; set; }
               
        public virtual ICollection<UserFundSubFundsColumn> UserFundSubFundsColumns { get; set; }
               
        public virtual ICollection<UserSubFundShareClassesColumn> UserSubFundShareClassesColumns { get; set; }

        public virtual ICollection<RecentlyViewed> RecentlyViewedItems { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
