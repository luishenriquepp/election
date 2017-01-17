using Election.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public interface IVoteRepository
    {
        IQueryable<Vote> GetAll();
        IQueryable<Vote> Get(Expression<Func<Vote, bool>> predicate);
        void Create(Vote vote);
        void Delete(int id);
        void Edit(Vote vote);
        Vote GetById(int id);
    }
}
