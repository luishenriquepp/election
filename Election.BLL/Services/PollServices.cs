using Election.BLL.IServices;
using Election.BLL.Utils;
using Election.DAL.Repository;
using Election.Models;
using System;
using System.Linq;

namespace Election.BLL.Services
{
    public class PollServices : IPollService
    {
        private IPollRepository _pollrepository;
        private IRestaurantRepository _restaurantRepository;

        public PollServices(IPollRepository pollRepository, IRestaurantRepository restaurantRepository)
        {
            _pollrepository = pollRepository;
            _restaurantRepository = restaurantRepository;
        }

        public IQueryable<Restaurant> GetAvailableRestaurants(DateTime date)
        {
            var create = new CreateElectionDateOfWeek(date);
            var weekKey = create.Get();
            var polls =  _pollrepository.Get(p => p.WeekOfYear == weekKey && p.Winner != null && p.DayOfWeek!= (int)date.DayOfWeek);

            IQueryable<Restaurant> winners = polls.Select(p => p.Winner);
            IQueryable<Restaurant> all = _restaurantRepository.GetAll();

            return all.Except(winners);
        }

        public Poll GetByDayOfWeak(DateTime date)
        {
            var create = new CreateElectionDateOfWeek(date);
            var weekKey = create.Get();
            var poll = _pollrepository.Get(p => p.WeekOfYear == weekKey && p.DayOfWeek == (int)date.DayOfWeek).FirstOrDefault();

            return poll;
        }

        public IQueryable<Poll> GetAll()
        {
            return _pollrepository.GetAll();
        }

        public void Create(Poll poll)
        {
            _pollrepository.Create(poll);
        }

        public void SelectWinner(DateTime date)
        {
            if(!(date.Hour >= 7 && date.Hour < 12))
            {
                var pollsWithoutWinner = _pollrepository.Get(p => p.Winner == null);
                foreach(var poll in pollsWithoutWinner.ToList())
                {
                    DefineWinner define = new DefineWinner(poll);
                    poll.WinnerId = define.Winner.Id;
                    _pollrepository.Edit(poll);
                }
            }
        }
    }
}