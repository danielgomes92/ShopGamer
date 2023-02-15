using Microsoft.EntityFrameworkCore;

namespace ShopGamer.Context
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext(DbContextOptions<LojinhaContext> options) : base(options)
        {

        }
        public DbSet<LojaGamer> LojaGamers { get; set; }
    }
}
