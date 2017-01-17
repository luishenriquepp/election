using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.BLL;

namespace Election.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var Date = new DateTime(2017, 01, 09);
            var CreatePK = new CreateElectionDateOfWeek(Date);

            var PrimaryKey = CreatePK.Get();

            Assert.AreEqual(PrimaryKey, "20172");
        }
        [TestMethod]
        public void TestMethod2()
        {
            var Date = new DateTime(2017, 01, 08);
            var CreatePK = new CreateElectionDateOfWeek(Date);

            var PrimaryKey = CreatePK.Get();

            Assert.AreEqual(PrimaryKey, "20171");
        }
        [TestMethod]
        public void TestMethod3()
        {
            var Date = new DateTime(2012, 12, 31);
            var CreatePK = new CreateElectionDateOfWeek(Date);

            var PrimaryKey = CreatePK.Get();

            Assert.AreEqual(PrimaryKey, "20131");
        }
    }
}
