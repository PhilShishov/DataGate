namespace DataGate.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RecentlyViewed
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string Link { get; set; }
    }
}
