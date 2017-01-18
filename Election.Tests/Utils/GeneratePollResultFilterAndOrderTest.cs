using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.BLL.Utils;
using Election.Models;
using System.Linq;
using System.Collections.Generic;
using Election.Tests.Factories;

namespace Election.Tests
{
    [TestClass]
    public class GeneratePollResultFilterAndOrderTest
    {
        [TestMethod]
        public void GeneratePollResultShouldIncludeAllRestaurants()
        {
            // Arrange
            var rFac = new RestaurantFactory();
            var pFac = new PollFactory("20171");

            // Act
            var generate = new GeneratePollResultFilterAndOrder(rFac.Get(20).ToList(), pFac.WithoutWinner("20171").ElementAt(0));
            var raws = generate.Get();

            // Assert
            Assert.AreEqual(20 , raws.Count());
        }

        [TestMethod]
        public void GeneratePollResultShouldPutTheMostVotedRestaurantOnTop()
        {
            // Arrange
            var rFac = new RestaurantFactory();
            var pFac = new PollFactory("20171");

            // Act
            var generate = new GeneratePollResultFilterAndOrder(rFac.Get(20).ToList(), pFac.WithoutWinner("20171").ElementAt(0));
            var raws = generate.Get();

            // Assert
            Assert.AreEqual(1, raws.First().Restaurant.Id);
        }

        [TestMethod]
        public void GeneratePollResultShouldCountVotesRight()
        {
            // Arrange
            var rFac = new RestaurantFactory();
            var pFac = new PollFactory("20171");

            // Act
            var generate = new GeneratePollResultFilterAndOrder(rFac.Get(20).ToList(), pFac.WithoutWinner("20171").ElementAt(0));
            var raws = generate.Get();

            // Assert
            Assert.AreEqual(5, raws.First().Votes);
        }

        [TestMethod]
        public void GeneratePollResultShouldPutTheSecondMostVotedOnSecondTop()
        {
            // Arrange
            var rFac = new RestaurantFactory();
            var pFac = new PollFactory("20171");

            // Act
            var generate = new GeneratePollResultFilterAndOrder(rFac.Get(20).ToList(), pFac.WithoutWinner("20171").ElementAt(0));
            var raws = generate.Get();

            // Assert
            Assert.AreEqual(2, raws.ElementAt(1).Restaurant.Id);
        }

        [TestMethod]
        public void GeneratePollResultShouldReturnRestaurantsWithoutVoutesIfPollIsNull()
        {
            // Arrange
            var rFac = new RestaurantFactory();
            var pFac = new PollFactory("20171");

            // Act
            var generate = new GeneratePollResultFilterAndOrder(rFac.Get(20).ToList(), null);
            var raws = generate.Get();

            // Assert
            Assert.AreEqual(0, raws.ElementAt(0).Votes);
        }
    }
}
