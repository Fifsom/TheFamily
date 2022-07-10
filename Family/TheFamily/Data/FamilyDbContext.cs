using Microsoft.EntityFrameworkCore;
using TheFamily.Entities;

namespace TheFamily.Data
{
    public class FamilyDbContext :DbContext
    {
        public FamilyDbContext(DbContextOptions<FamilyDbContext> options)
            : base(options)
        {

        }

        public DbSet<Player>? player { get; set; }
    }
}
