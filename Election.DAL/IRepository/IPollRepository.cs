using Election.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public interface IPollRepository
    {
        IQueryable<Poll> GetAll();
        IQueryable<Poll> Get(Expression<Func<Poll, bool>> predicate);
        void Create(Poll poll);
        void Delete(int id);
        void Edit(Poll restaurant);
        Poll GetById(int id);
    }
}
