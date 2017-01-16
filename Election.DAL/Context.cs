using Election.Models;
using System.Data.Entity;

namespace Election.DAL
{
    public class Context : DbContext
    {
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Poll> Election { get; set; }
        public DbSet<Vote> Vote { get; set; }
    }
}
