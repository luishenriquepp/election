using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.BLL.Utils;
using Election.Models;
using System.Linq;
using System.Collections.Generic;

namespace Election.Tests
{
    [TestClass]
    public class CreatePollViewModelTest
    {
        [TestMethod]
        public void DicionaryShouldReturn4()
        {
            var rest1 = new Restaurant { Id = 1, Name = "McDonalds" };
            var rest2 = new Restaurant { Id = 2, Name = "BurguerKing" };
            var rest3 = new Restaurant { Id = 3, Name = "China In Box" };
            var rest4 = new Restaurant { Id = 4, Name = "Bobs" };
            List<Restaurant> list = new List<Restaurant>
            {
                rest1, rest2,rest3, rest4,
                new Restaurant { Id = 5, Name = "Cenoura Pasteis" },
                new Restaurant { Id = 6, Name = "Georges Pasteis" },
                new Restaurant { Id = 7, Name = "Toquio Sushi" },
                new Restaurant { Id = 8, Name = "Daisukê" },
                new Restaurant { Id = 9, Name = "Japesca" },
                new Restaurant { Id = 10, Name = "Petisqueira" }
            };
            Poll poll = new Poll
            { Id = 1, Votes = new List<Vote>
                {
                    new Vote { Id = 1, Restaurant = rest1 },
                    new Vote { Id = 2, Restaurant = rest1 },
                    new Vote { Id = 3, Restaurant = rest1 },
                    new Vote { Id = 4, Restaurant = rest1 },
                    new Vote { Id = 5, Restaurant = rest2 },
                    new Vote { Id = 6, Restaurant = rest2 },
                    new Vote { Id = 7, Restaurant = rest2 },
                    new Vote { Id = 8, Restaurant = rest3 },
                    new Vote { Id = 9, Restaurant = rest3 },
                    new Vote { Id = 10, Restaurant = rest4 },
                    new Vote { Id = 11, Restaurant = rest4 }
                }
            };
            CreatePollViewModel cpVM = new CreatePollViewModel(list, poll);

            var raws = cpVM.Get();

            Assert.AreEqual(raws.Count(), 4);
        }
    }
}
