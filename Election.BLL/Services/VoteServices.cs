using Election.BLL.IServices;
using System;
using System.Linq;
using Election.Models;
using Election.DAL.Repository;

namespace Election.BLL.Services
{
    public class VoteServices : IVoteService
    {
        private IPollService _pollService;
        private IVoteRepository _voteRepository;

        public VoteServices(IPollService pollService, IVoteRepository voteRepository)
        {
            _pollService = pollService;
            _voteRepository = voteRepository;
        }

        public void Create(Vote vote)
        {
            var create = new CreateWeekOfYearElection(DateTime.Now);
            var weekKey = create.Get();
            var poll = _pollService.GetByWeekOfYear(DateTime.Now);
            if(poll == null)
            {
                poll = new Poll { WeekOfYear = weekKey, DayOfWeek = (int)DateTime.Now.DayOfWeek };
                _pollService.Create(poll);
            }
            vote.PollId = poll.Id;
            _voteRepository.Create(vote);
        }

        public void Edit(Vote vote)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vote GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
