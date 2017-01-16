using Election.Models;
using System.Data.Entity;

namespace Election.DAL
{
    public class Context : DbContext
    {
        public IDbSet<Restaurant> Restaurant { get; set; }
        public IDbSet<Poll> Election { get; set; }
        public IDbSet<Vote> Vote { get; set; }
    }
}
