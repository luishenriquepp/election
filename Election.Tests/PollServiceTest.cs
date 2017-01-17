using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Election.BLL.Services;
using System.Linq;
using Election.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using Election.DAL.Repository;

namespace Election.Tests
{
    [TestClass]
    public class PollServiceTest
    {
        [TestMethod]
        public void GetAvailableRestaurntsTest()
        {
            // Arrange
            Mock<IPollRepository> pMock = new Mock<IPollRepository>();
            Mock<IRestaurantRepository> rMock = new Mock<IRestaurantRepository>();
            var rest1 = new Restaurant { Id = 1, Name = "McDonalds" };
            var rest2 = new Restaurant { Id = 2, Name = "BurguerKing" };
            var rest3 = new Restaurant { Id = 3, Name = "China In Box" };
            var rest4 = new Restaurant { Id = 4, Name = "Bobs" };
            IQueryable<Restaurant> list = new List<Restaurant>
            {
                rest1, rest2,rest3, rest4,
                new Restaurant { Id = 5, Name = "Cenoura Pasteis" },
                new Restaurant { Id = 6, Name = "Georges Pasteis" },
                new Restaurant { Id = 7, Name = "Toquio Sushi" },
                new Restaurant { Id = 8, Name = "Daisukê" },
                new Restaurant { Id = 9, Name = "Japesca" },
                new Restaurant { Id = 10, Name = "Petisqueira" }
            }.AsQueryable();

            IQueryable<Poll> polls = new List<Poll>
            {
                new Poll { Id = 1, WeekOfYear = "20171", Winner =  rest1 },
                new Poll { Id = 2, WeekOfYear = "20171", Winner =  rest2 },
                new Poll { Id = 3, WeekOfYear = "20171", Winner =  rest3 },
                new Poll { Id = 4, WeekOfYear = "20171", Winner =  rest4 },
            }.AsQueryable();
            rMock.Setup(r => r.GetAll()).Returns(list);
            pMock.Setup(r => r.Get(It.IsAny<Expression<Func<Poll, bool>>>())).Returns(polls);
            var services = new PollServices(pMock.Object, rMock.Object);

            // Act
            DateTime date = new DateTime(2017, 1, 9);
            IQueryable<Restaurant> rests = services.GetAvailableRestaurants(date);

            // Assert
            Assert.AreEqual(rests.Count(), 6);
        }
    }
}
