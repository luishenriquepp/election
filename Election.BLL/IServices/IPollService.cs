using Election.Models;
using System;
using System.Linq;

namespace Election.BLL.IServices
{
    public interface IPollService
    {
        IQueryable<Restaurant> GetAvailableRestaurants(DateTime time);
        IQueryable<Poll> GetAll();
        Poll GetByWeekOfYear(DateTime date);
        void Create(Poll poll);
        void SelectWinner(DateTime date);
    }
}
