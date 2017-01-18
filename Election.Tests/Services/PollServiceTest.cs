using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Election.BLL.Services;
using System.Linq;
using Election.Models;
using System.Linq.Expressions;
using Election.DAL.Repository;
using Election.Tests.Factories;

namespace Election.Tests
{
    [TestClass]
    public class PollServiceTest
    {
        Mock<IPollRepository> pMock;
        Mock<IRestaurantRepository> rMock;
        public Expression<Func<Poll, bool>> True<Poll>() { return f => true; }

        [TestInitialize]
        public void Initialize()
        {
            pMock = new Mock<IPollRepository>();
            rMock = new Mock<IRestaurantRepository>();
        }

        [TestMethod]
        public void GetAvailableRestaurantsTest()
        {
            // Arrange
            RestaurantFactory rFac = new RestaurantFactory();
            PollFactory pFac = new PollFactory("20173");

            rMock.Setup(r => r.GetAll()).Returns(rFac.Get(20).AsQueryable());
            pMock.Setup(r => r.Get(It.IsAny<Func<Poll, bool>>())).Returns(pFac.Polls);
            var services = new PollServices(pMock.Object, rMock.Object);

            // Act
            DateTime date = new DateTime(2017, 1, 20);
            int opa = (int)date.DayOfWeek;
            IQueryable<Restaurant> rests = services.GetAvailableRestaurants(date);

            // Assert
            Assert.AreEqual(15, rests.Count());
        }

        [TestMethod]
        public void SelectWinnerShouldWorkAt6Hours()
        {
            var pollService = new PollServices(pMock.Object, rMock.Object);

            pollService.SelectWinner(new DateTime(2020, 4, 30, 6,59,0));

            pMock.Verify(p => p.Get(It.IsAny<Func<Poll, bool>>()), Times.Exactly(1));
        }

        [TestMethod]
        public void SelectWinnerShouldWorkAt12Hours()
        {
            var pollService = new PollServices(pMock.Object, rMock.Object);

            pollService.SelectWinner(new DateTime(2020, 4, 30, 12, 0, 0));

            pMock.Verify(p => p.Get(It.IsAny<Func<Poll, bool>>()), Times.Exactly(1));
        }


        [TestMethod]
        public void SelectWinnerShouldNotWorkAt7Hours()
        {
            var pollService = new PollServices(pMock.Object, rMock.Object);

            pollService.SelectWinner(new DateTime(2020, 4, 30, 7, 0, 0));

            pMock.Verify(p => p.Get(It.IsAny<Func<Poll, bool>>()), Times.Never());
        }

        [TestMethod]
        public void SelectWinnerShouldNotWorkAt11Hours()
        {
            var pollService = new PollServices(pMock.Object, rMock.Object);

            pollService.SelectWinner(new DateTime(2020, 4, 30, 11, 0, 0));

            pMock.Verify(p => p.Get(It.IsAny<Func<Poll, bool>>()), Times.Never());
        }
    }
}
