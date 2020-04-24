namespace DataGate.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using DataGate.Domain.Models.Users;
    using DataGate.Data.Configurations;

    public class Pharus_UsersDbContext : IdentityDbContext<PharusUser, PharusRole, string, IdentityUserClaim<string>,
                            PharusUserRole, IdentityUserLogin<string>,
                            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public Pharus_UsersDbContext()
        {
        }

        public Pharus_UsersDbContext(DbContextOptions<Pharus_UsersDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConnectionStringPharusUsers);
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
