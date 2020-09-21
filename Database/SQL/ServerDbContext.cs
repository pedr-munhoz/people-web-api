using Microsoft.EntityFrameworkCore;
using people_web_api.Models.SQL;

namespace people_web_api.Database.SQL
{
    public class ServerDbContext : BaseDbContext
    {
        public DbSet<User> Users { get; set; }

        public ServerDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }
    }
}