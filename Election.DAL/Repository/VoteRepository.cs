using Election.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public class VoteRepository : IVoteRepository
    {
        private ApplicationDbContext Context;

        public VoteRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public void Create(Vote vote)
        {
            Context.Vote.Add(vote);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Vote vote)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> Get(Expression<Func<Vote, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vote GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
