using Election.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public interface IRestaurantRepository
    {
        IQueryable<Restaurant> GetAll();
        IQueryable<Restaurant> Get(Expression<Func<Restaurant, bool>> predicate);
        Restaurant Create(Restaurant restaurant);
        void Delete(int id);
        Restaurant Edit(Restaurant restaurant);
        Restaurant GetById(int id);
    }
}
