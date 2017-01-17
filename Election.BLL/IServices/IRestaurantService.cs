using Election.Models;
using System.Linq;

namespace Election.BLL.IServices
{
    public interface IRestaurantService
    {
        void Create(Restaurant restaurant);
        IQueryable<Restaurant> GetAll();
        void Remove(int id);
        void Edit(Restaurant restaurant);
        Restaurant GetById(int id);
    }
}
