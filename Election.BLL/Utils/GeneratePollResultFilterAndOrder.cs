using Election.Models;
using System.Collections.Generic;
using System.Linq;

namespace Election.BLL.Utils
{
    public class GeneratePollResultFilterAndOrder
    {
        private List<Restaurant> Availables { get; set; }
        private Poll TodayPoll { get; set; }

        public GeneratePollResultFilterAndOrder(List<Restaurant> availables, Poll today)
        {
            Availables = availables;
            TodayPoll = today;
        }

        public List<VoteRaw> Get()
        {
            List<VoteRaw> raw = new List<VoteRaw>();
            foreach (var rest in Availables)
            {
                raw.Add(new VoteRaw { Restaurant = rest, Votes = 0 });
            }
            if(TodayPoll != null)
            {
                foreach (var vote in TodayPoll.Votes)
                {
                    var selectedRaw = raw.First(r => r.Restaurant.Id == vote.RestaurantId);
                    selectedRaw.Votes++;
                }
            }
            return raw.OrderByDescending(r => r.Votes).ToList();
        }
    }
    public class VoteRaw
    {
        public Restaurant Restaurant { get; set; }
        public int Votes { get; set; }
    }
}
