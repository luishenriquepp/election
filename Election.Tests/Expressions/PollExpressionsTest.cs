using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.Tests.Factories;
using Election.Models;
using System.Collections.Generic;
using System.Linq;
using Election.BLL.Expressions;

namespace Election.Tests.Expressions
{
    [TestClass]
    public class PollExpressionsTest
    {
        [TestMethod]
        public void GetSomeWeekPollsShouldIgnoreToday()
        {
            // Arrange
            RestaurantFactory rFac = new RestaurantFactory();
            PollFactory pFac = new PollFactory("20173");
            List<Poll> polls = pFac.Polls;

            // Act
            PollServiceExpressions exp = new PollServiceExpressions();
            var newPolls = polls.Where(exp.GetSameWeekPollsExceptFromToday(new DateTime(2017, 1, 20)));

            // Assert
            Assert.AreEqual(4, newPolls.Count());
        }
        [TestMethod]
        public void GetSomeWeekPollsShouldIgnoreOthersWeeks()
        {
            // Arrange
            RestaurantFactory rFac = new RestaurantFactory();
            PollFactory pFac1 = new PollFactory("20171");
            PollFactory pFac2 = new PollFactory("20172");
            PollFactory pFac3 = new PollFactory("20173");
            List<Poll> polls = pFac1.Polls;
            polls.AddRange(pFac2.Polls);
            polls.AddRange(pFac3.Polls);
            // Act
            PollServiceExpressions exp = new PollServiceExpressions();
            var newPolls = polls.Where(exp.GetSameWeekPollsExceptFromToday(new DateTime(2017, 1, 20)));

            // Assert
            Assert.AreEqual(4, newPolls.Count());
        }
        [TestMethod]
        public void GetSomeWeekPollsShouldIgnorePollsWithoutWinner()
        {
            // Arrange
            RestaurantFactory rFac = new RestaurantFactory();
            PollFactory pFac1 = new PollFactory("20171");
            PollFactory pFac2 = new PollFactory("20172");
            PollFactory pFac3 = new PollFactory("20173");
            List<Poll> polls = pFac1.Polls;
            polls.AddRange(pFac2.Polls);
            polls.AddRange(pFac3.Polls);
            polls.AddRange(pFac1.WithoutWinner("20173"));
            // Act
            PollServiceExpressions exp = new PollServiceExpressions();
            var newPolls = polls.Where(exp.GetSameWeekPollsExceptFromToday(new DateTime(2017, 1, 20)));

            // Assert
            Assert.AreEqual(4, newPolls.Count());
        }

        [TestMethod]
        public void GetPollBySameWeekAndSameDayOfWeek()
        {
            // Arrange
            RestaurantFactory rFac = new RestaurantFactory();
            PollFactory pFac1 = new PollFactory("20173");
            List<Poll> polls = pFac1.Polls;
            // Act

            PollServiceExpressions exp = new PollServiceExpressions();
            var poll = polls.Where(exp.GetPollByWeekOfYear(new DateTime(2017, 1, 20)));

            // Assert
            Assert.AreEqual(polls.Find(p => p.Id == 5).Id, poll.First().Id);
        }
    }
}
