using Election.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public interface IPollRepository
    {
        IQueryable<Poll> GetAll();
        IEnumerable<Poll> Get(Func<Poll, bool> predicate);
        void Create(Poll poll);
        void Delete(int id);
        void Edit(Poll restaurant);
        Poll GetById(int id);
    }
}
