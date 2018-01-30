using Election.Models;
using System.Linq;

namespace Election.BLL.IServices
{
    public interface IRestaurantService
    {
        Restaurant Create(Restaurant restaurant);
        IQueryable<Restaurant> GetAll();
        void Remove(int id);
        Restaurant Edit(Restaurant restaurant);
        Restaurant GetById(int id);
    }
}
