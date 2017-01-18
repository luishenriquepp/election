using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.Tests.Factories;
using System.Collections.Generic;
using Election.Models;
using Election.BLL.Utils;
using System.Linq;

namespace Election.Tests.Utils
{
    [TestClass]
    public class DefineWinnerTest
    {
        [TestMethod]
        public void DefineWinnerShouldTakeTheMostVotedRestaurant()
        {
            // Arrange
            PollFactory factory = new PollFactory("20171");
            List<Poll> polls = factory.WithoutWinner("20171");

            // Act
            DefineWinner define = new DefineWinner(polls.First(p => p.Id == 6));

            // Assert
            Assert.AreEqual(1, define.Winner.Id);
        }
        [TestMethod]
        public void DefineWinnerShouldAssumeOneVotedRestaurantAsElected()
        {
            // Arrange
            PollFactory factory = new PollFactory("20171");
            List<Poll> polls = factory.WithoutWinner("20171");

            // Act
            DefineWinner define = new DefineWinner(polls.First(p => p.Id == 7));

            // Assert
            Assert.AreEqual(5, define.Winner.Id);
        }
        [TestMethod]
        public void DefineWinnerShouldChoseRandomWhenDraw()
        {
            // Arrange
            PollFactory factory = new PollFactory("20171");
            List<Poll> polls = factory.WithoutWinner("20171");

            // Act
            DefineWinner define = new DefineWinner(polls.First(p => p.Id == 8));

            // Assert
            Assert.AreEqual(2, define.Winner.Id);
        }
    }
}
