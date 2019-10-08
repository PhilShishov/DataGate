
namespace Pharus.Data.Seeding
{
    using System.Linq;

    using Pharus.Domain.Users;

    public class PharusUserRoleSeeder : ISeeder
    {
        private readonly PharusUsersDbContext context;

        public PharusUserRoleSeeder(PharusUsersDbContext context)
        {
            this.context = context;
        }
        public void Seed()
        {
            this.context.Database.EnsureCreated();

            if (!this.context.Roles.Any())
            {
                this.context.Roles.Add(new PharusRole { Name = "Admin", NormalizedName = "ADMIN" });
                this.context.Roles.Add(new PharusRole { Name = "Legal", NormalizedName = "LEGAL" });
                this.context.Roles.Add(new PharusRole { Name = "Risk", NormalizedName = "RISK" });
                this.context.Roles.Add(new PharusRole { Name = "Compliance", NormalizedName = "COMPLIANCE" });
                this.context.Roles.Add(new PharusRole { Name = "Investment", NormalizedName = "INVESTMENT" });
            }

            this.context.SaveChanges();
        }
    }
}
