// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RecentlyViewed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string DisplayLink { get; set; }
    }
}
