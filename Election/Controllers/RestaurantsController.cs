using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Election.Models;
using Election.BLL.IServices;
using System;

namespace Election.Controllers
{
    public class RestaurantsController : ApiController
    {
        private IRestaurantService _service;

        public RestaurantsController(IRestaurantService service)
        {
            _service = service;
        }

        // GET: api/Restaurants
        public IQueryable<Restaurant> GetRestaurants()
        {
            return _service.GetAll();
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurant(int id)
        {
            Restaurant restaurant = _service.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            try
            {
                var added = _service.Edit(restaurant);

                if (added == null)
                    return InternalServerError(new Exception("Duplicated restaurant."));
            }
            catch (DbUpdateConcurrencyException)
            {
                 throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Restaurants
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var added = _service.Create(restaurant);

            if (added == null)
                return InternalServerError(new Exception("Duplicated restaurant."));

            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            _service.Remove(id);
                
            return Ok();
        }
    }
}