using System.ComponentModel.DataAnnotations;

namespace Catgeory_Ef.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCategory> subCategories { get; set; }
    }
}
