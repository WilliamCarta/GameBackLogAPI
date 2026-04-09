using Microsoft.EntityFrameworkCore;

namespace GameBackLogApi
{
    public class GameBackLogContext : DbContext
    {
        public GameBackLogContext(DbContextOptions<GameBackLogContext> options) : base(options)
        {  
        }

        public DbSet<Game> Games {  get; set; }
        public DbSet<User> Users { get; set; }
    }
}
