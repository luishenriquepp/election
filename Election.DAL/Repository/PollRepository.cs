using Election.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public class PollRepository : IPollRepository
    {
        private Context Context;

        public PollRepository(Context context)
        {
            this.Context = context;
        }

        public IQueryable<Poll> GetAll()
        {
            return Context.Election;
        }

        public IQueryable<Poll> Get(Expression<Func<Poll,  bool>> predicate)
        {
            return Context.Election.Where(predicate);
        }

        public void Create(Poll poll)
        {
            Context.Election.Add(poll);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = Context.Restaurant.Find(id);
            Context.Restaurant.Remove(restaurant);
            Context.SaveChanges();
        }

        public void Edit(Poll restaurant)
        {
            Context.Entry(restaurant).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public Poll GetById(int id)
        {
            return Context.Election.Find(id);
        }
    }
}
