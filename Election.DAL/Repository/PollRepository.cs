using Election.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Election.DAL.Repository
{
    public class PollRepository : IPollRepository
    {
        private ApplicationDbContext Context;

        public PollRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public IQueryable<Poll> GetAll()
        {
            return Context.Election;
        }

        public IEnumerable<Poll> Get(Func<Poll, bool> predicate)
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
