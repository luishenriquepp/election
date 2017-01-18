using Election.BLL.Utils;
using System.Collections.Generic;

namespace Election.Models
{
    public class ElectionViewModel
    {
        public List<VoteRaw> ElectionVotes { get; set; }
        public bool Voted { get; set; }
        public int WinnerId { get; set; }
    }
}