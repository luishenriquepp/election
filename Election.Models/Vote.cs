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
        [Required]
        public string UserToken { get; set; }
    }
}