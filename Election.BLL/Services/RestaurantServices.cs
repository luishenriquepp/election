using Election.BLL.IServices;
using Election.DAL.Repository;
using Election.Models;
using System.Linq;

namespace Election.BLL.Services
{
    public class RestaurantServices : IRestaurantService
    {
        private IRestaurantRepository _repository;

        public RestaurantServices(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public Restaurant Create(Restaurant restaurant)
        {
            if (!IsDuplicated(restaurant))
            {
                return null;
            }

            return _repository.Create(restaurant);
        }

        public IQueryable<Restaurant> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public Restaurant Edit(Restaurant restaurant)
        {
            if (!IsDuplicated(restaurant))
            {
                return null;
            }

            return _repository.Edit(restaurant);
        }

        public Restaurant GetById(int id)
        {
            return _repository.GetById(id);
        }

        private bool IsDuplicated(Restaurant restaurant)
        {
            var existing = _repository.Get(r => r.Name.ToLower() == restaurant.Name.ToLower()).FirstOrDefault();

            return !(existing != null && restaurant.Id != existing.Id);
        }
    }
}
