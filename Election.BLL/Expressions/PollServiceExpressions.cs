using Election.Models;
using System;

namespace Election.BLL.Expressions
{
    public class PollServiceExpressions
    {
        public Func<Poll, bool> GetSameWeekPollsExceptFromToday(DateTime date)
        {
            var create = new CreateWeekOfYearElection(date);
            var weekKey = create.Get();
            return p => p.WeekOfYear == weekKey && p.Winner != null && p.DayOfWeek != (int)date.DayOfWeek;
        }

        public Func<Poll, bool> GetPollByWeekOfYear(DateTime date)
        {
            var create = new CreateWeekOfYearElection(date);
            var weekKey = create.Get();
            return p => p.WeekOfYear == weekKey && p.DayOfWeek == (int)date.DayOfWeek;
        }
    }
}
