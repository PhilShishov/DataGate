// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RecentlyViewed
    {
        public RecentlyViewed()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string LinkUrl { get; set; }

        [Required]
        public string DisplayLink { get; set; }

        public DateTime VisitedOn { get; set; }
    }
}
