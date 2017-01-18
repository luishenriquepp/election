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

        public override bool Equals(object obj)
        {
            var item = obj as Restaurant;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
