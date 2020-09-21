using Microsoft.EntityFrameworkCore;

namespace people_web_api.Database.SQL
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityAlwaysColumns();

            base.OnModelCreating(modelBuilder);
        }
    }
}