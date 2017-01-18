using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Election.BLL.Services;
using Election.BLL.IServices;
using Moq;
using Election.DAL.Repository;
using Election.Models;

namespace Election.Tests.Services
{
    [TestClass]
    public class VoteServiceTest
    {
        [TestMethod]
        public void CreateVoteShouldCreatePollIfNotExists()
        {
            Mock<IPollService> pMock = new Mock<IPollService>();
            Mock<IVoteRepository> vMock = new Mock<IVoteRepository>();
            Poll poll = null;
            pMock.Setup(p => p.GetByWeekOfYear(It.IsAny<DateTime>())).Returns(poll);

            IVoteService voteService = new VoteServices(pMock.Object, vMock.Object);
            voteService.Create(new Vote());
            pMock.Verify(m => m.Create(It.IsAny<Poll>()));
        }
        [TestMethod]
        public void CreateVoteShouldNotCreatePollIfNotExists()
        {
            Mock<IPollService> pMock = new Mock<IPollService>();
            Mock<IVoteRepository> vMock = new Mock<IVoteRepository>();
            Poll poll = new Poll();
            pMock.Setup(p => p.GetByWeekOfYear(It.IsAny<DateTime>())).Returns(poll);

            IVoteService voteService = new VoteServices(pMock.Object, vMock.Object);
            voteService.Create(new Vote());
            pMock.Verify(m => m.Create(It.IsAny<Poll>()), Times.Never());
        }
        [TestMethod]
        public void CreateVoteShouldCallRepositoryCreate()
        {
            Mock<IPollService> pMock = new Mock<IPollService>();
            Mock<IVoteRepository> vMock = new Mock<IVoteRepository>();
            IVoteService voteService = new VoteServices(pMock.Object, vMock.Object);
            voteService.Create(new Vote());
            vMock.Verify(m => m.Create(It.IsAny<Vote>()), Times.Exactly(1));
        }

    }
}
