
namespace Pharus.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using Pharus.Domain;

    public class PharusDbContext : IdentityDbContext<PharusUser, PharusUserRole, string>
    {
        public PharusDbContext()
        {
        }
        public PharusDbContext(DbContextOptions<PharusDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PharusDb;Trusted_Connection=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PharusUser>()
                .HasKey(user => user.Id);           

            base.OnModelCreating(modelBuilder);
        }
    }
}
