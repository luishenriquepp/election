using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Election.Models
{
    public class Poll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string WeekOfYear { get; set; }
        public DateTime Day { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
