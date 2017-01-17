using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Election.Models
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }
        public string WeekOfYear { get; set; }
        public int DayOfWeek { get; set; }

        public int? WinnerId { get; set; }
        public Restaurant Winner { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
