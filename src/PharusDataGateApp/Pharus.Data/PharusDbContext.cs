
namespace Pharus.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Pharus.Domain;

    public class PharusDbContext : IdentityDbContext<PharusUser>
    {
        public PharusDbContext(DbContextOptions<PharusDbContext> options) : base(options)
        {

        }
    }
}
