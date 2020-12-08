﻿namespace DataGate.Data.Models.Columns
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Data.Models.Users;

    public class UserSubFundColumn : IUserColumn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}