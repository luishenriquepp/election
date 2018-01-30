using Election.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Election.DAL.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ApplicationDbContext Context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public IQueryable<Restaurant> GetAll()
        {
            return Context.Restaurant;
        }

        public IQueryable<Restaurant> Get(Expression<Func<Restaurant, bool>> predicate)
        {
            return Context.Restaurant.Where(predicate);
        }

        public Restaurant Create(Restaurant restaurant)
        {
            Context.Restaurant.Add(restaurant);
            Context.SaveChanges();

            return restaurant;
        }

        public void Delete(int id)
        {
            var restaurant = Context.Restaurant.Find(id);
            Context.Restaurant.Remove(restaurant);
            Context.SaveChanges();
        }

        public Restaurant Edit(Restaurant restaurant)
        {
            Context.Entry(restaurant).State = EntityState.Modified;
            Context.SaveChanges();

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return Context.Restaurant.Find(id);            
        }
    }
}
