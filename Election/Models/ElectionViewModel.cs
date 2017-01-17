using Election.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Election.Models
{
    public class ElectionViewModel
    {
        public List<VoteRaw> ElectionVotes { get; set; }
        public bool Voted { get; set; }
    }
}