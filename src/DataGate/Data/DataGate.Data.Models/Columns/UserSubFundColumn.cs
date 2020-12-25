// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Data.Models.Columns
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Data.Models.Users;

    public class UserSubFundColumn : IUserColumn
    {
        public UserSubFundColumn()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
