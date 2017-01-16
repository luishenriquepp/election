using System.ComponentModel.DataAnnotations;

namespace Election.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Neighborhood { get; set; }
    }
}
