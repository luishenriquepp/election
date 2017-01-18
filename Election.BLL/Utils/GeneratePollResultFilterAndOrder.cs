using Election.Models;
using System.Collections.Generic;
using System.Linq;

namespace Election.BLL.Utils
{
    public class GeneratePollResultFilterAndOrder
    {
        private List<Restaurant> Restaurants { get; set; }
        private Poll Poll { get; set; }

        public GeneratePollResultFilterAndOrder(List<Restaurant> restaurants, Poll poll)
        {
            Restaurants = restaurants;
            Poll = poll;
        }

        public List<VoteRaw> Get()
        {
            List<VoteRaw> raw = new List<VoteRaw>();
            foreach (var rest in Restaurants)
            {
                raw.Add(new VoteRaw { Restaurant = rest, Votes = 0 });
            }
            if(Poll != null)
            {
                foreach (var vote in Poll.Votes)
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
