using Election.Models;
using System.Collections.Generic;
using System.Linq;

namespace Election.Tests.Factories
{
    internal class RestaurantFactory
    {
        public List<Restaurant> Restaurants { get; set; }

        public RestaurantFactory()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "McDonalds" },
                new Restaurant { Id = 2, Name = "BurguerKing" },
                new Restaurant { Id = 3, Name = "China In Box" },
                new Restaurant { Id = 4, Name = "Bobs" },
                new Restaurant { Id = 5, Name = "Cenoura Pasteis" },
                new Restaurant { Id = 6, Name = "Georges Pasteis" },
                new Restaurant { Id = 7, Name = "Toquio Sushi" },
                new Restaurant { Id = 8, Name = "Daisukê" },
                new Restaurant { Id = 9, Name = "Japesca" },
                new Restaurant { Id = 10, Name = "Pampa Burguer" },
                new Restaurant { Id = 11, Name = "Habitat" },
                new Restaurant { Id = 12, Name = "Frango e Cia" },
                new Restaurant { Id = 13, Name = "Chef Carnes" },
                new Restaurant { Id = 14, Name = "Usina das Massas" },
                new Restaurant { Id = 15, Name = "Guris" },
                new Restaurant { Id = 16, Name = "Pastel com Borda" },
                new Restaurant { Id = 17, Name = "Cachorro do Bigode" },
                new Restaurant { Id = 18, Name = "Cachorro do Bonfa" },
                new Restaurant { Id = 19, Name = "Naturaze" },
                new Restaurant { Id = 20, Name = "Saint Diego" }
            };
        }

        public IEnumerable<Restaurant> Get(int amount)
        {
            return Restaurants.Take(amount);
        }
    }
}
