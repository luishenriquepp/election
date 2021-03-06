﻿using Election.Models;
using System.Linq;

namespace Election.BLL.Utils
{
    public class DefineWinner
    {
        private Poll Poll { get; set; }
        public Restaurant Winner{ get; set; }

        public DefineWinner(Poll pollsWithoutWinner)
        {
            Poll = pollsWithoutWinner;
            Define();
        }

        private void Define()
        {
            var winner = Poll.Votes.GroupBy(v => v.RestaurantId)
                            .Select(t => new { RestaurantId = t.Key, Count = t.Count() })
                            .OrderByDescending(t => t.Count)
                            .First();
            Winner = new Restaurant { Id = winner.RestaurantId };
        }

    }
}
