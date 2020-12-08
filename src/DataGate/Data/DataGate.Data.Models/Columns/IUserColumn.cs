namespace DataGate.Data.Models.Columns
{
    using DataGate.Data.Models.Users;

    public interface IUserColumn
    {
        int Id { get; set; }

        string Name { get; set; }

        string UserId { get; set; }

        ApplicationUser User { get; set; }
    }
}
