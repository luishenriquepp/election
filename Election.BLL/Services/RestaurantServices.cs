using Election.BLL.IServices;
using Election.DAL.Repository;
using Election.Models;
using System.Linq;

namespace Election.BLL.Services
{
    public class RestaurantServices : IRestaurantService
    {
        private RestaurantRepository _repository;

        public RestaurantServices(RestaurantRepository repository)
        {
            _repository = repository;
        }

        public void Create(Restaurant restaurant)
        {
            _repository.Create(restaurant);
        }

        public IQueryable<Restaurant> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public void Edit(Restaurant restaurant)
        {
            _repository.Edit(restaurant);
        }

        public Restaurant GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
