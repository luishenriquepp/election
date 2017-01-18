using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.BLL;

namespace Election.Tests.Utils
{
    [TestClass]
    public class CreateElectionWeekOfYearKeyTest
    {
        public void CreateWeekOfYearKeyShouldReturn20172()
        {
            var Date = new DateTime(2017, 01, 09);
            var CreateKey = new CreateWeekOfYearElection(Date);

            var WeekKey = CreateKey.Get();

            Assert.AreEqual(WeekKey, "20172");
        }
        [TestMethod]
        public void CreateWeekOfYearKeyShouldReturn20171()
        {
            var Date = new DateTime(2017, 01, 08);
            var CreateKey = new CreateWeekOfYearElection(Date);

            var WeekKey = CreateKey.Get();

            Assert.AreEqual(WeekKey, "20171");
        }
        [TestMethod]
        public void CreateWeekOfYearKeyShouldReturn20131()
        {
            var Date = new DateTime(2012, 12, 31);
            var CreateKey = new CreateWeekOfYearElection(Date);

            var WeekKey = CreateKey.Get();

            Assert.AreEqual(WeekKey, "20131");
        }
    }
}
