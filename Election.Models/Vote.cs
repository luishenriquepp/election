using System.ComponentModel.DataAnnotations;

namespace Election.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public string UserToken { get; set; }
        public int PollId { get; set; }
        public Poll Poll { get; set; }
    }
}