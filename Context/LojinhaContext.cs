using Microsoft.EntityFrameworkCore;
using ShopGamer.Models;

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
