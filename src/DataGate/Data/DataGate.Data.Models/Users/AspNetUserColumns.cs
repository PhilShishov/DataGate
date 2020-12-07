namespace DataGate.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class AspNetUserColumns
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
