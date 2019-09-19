
namespace Pharus.Data
{
    using Pharus.Domain;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Pharus.Domain.Users;
    using Microsoft.AspNetCore.Identity;

    public class PharusUsersDbContext : IdentityDbContext<PharusUser, PharusRole, string, IdentityUserClaim<string>,
                            PharusUserRole, IdentityUserLogin<string>,
                            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public PharusUsersDbContext()
        {
        }
        public PharusUsersDbContext(DbContextOptions<PharusUsersDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PharusUsersDb;Trusted_Connection=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PharusUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
