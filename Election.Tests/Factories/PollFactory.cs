using Election.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Election.Tests.Factories
{
    internal class PollFactory
    {
        public List<Poll> Polls { get; set; }
        private IEnumerable<Restaurant> restaurants { get; set; }

        public PollFactory(string WeekOfYear)
        {
            RestaurantFactory factory = new RestaurantFactory();
            restaurants = factory.Get(5);
            Polls = new List<Poll>
            {
                new Poll { Id = 1, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Monday, Winner =  restaurants.ElementAt(0) },
                new Poll { Id = 2, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Tuesday, Winner =  restaurants.ElementAt(1) },
                new Poll { Id = 3, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Wednesday, Winner =  restaurants.ElementAt(2) },
                new Poll { Id = 4, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Thursday, Winner =  restaurants.ElementAt(3) },
                new Poll { Id = 5, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Friday, Winner =  restaurants.ElementAt(4) },
            };
        }

        public List<Poll> WithoutWinner(string WeekOfYear)
        {
            return new List<Poll>
            {
                new Poll { Id = 6, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Monday, Votes = new List<Vote>()
                {
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 3 },
                    new Vote { RestaurantId = 3 },
                    new Vote { RestaurantId = 4 },
                    new Vote { RestaurantId = 5 },
                    new Vote { RestaurantId = 5 },
                    new Vote { RestaurantId = 1 },
                } },
                new Poll { Id = 7, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Tuesday, Votes = new List<Vote>()
                {
                    new Vote { RestaurantId = 5 }
                } },
                new Poll { Id = 8, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Wednesday, Votes = new List<Vote>()
                {
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 1 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                    new Vote { RestaurantId = 2 },
                } },
                new Poll { Id = 9, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Thursday },
                new Poll { Id = 10, WeekOfYear = WeekOfYear, DayOfWeek = (int)DayOfWeek.Friday  },
            };
        }
    }
}
