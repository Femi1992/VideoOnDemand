using VideoOnDemand.Data.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VideoOnDemand.Data.Data
{
    public class VODContext : IdentityDbContext<User>
    {
        public VODContext(DbContextOptions<VODContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
