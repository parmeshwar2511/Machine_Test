using System.ComponentModel.DataAnnotations;

namespace Catgeory_Ef.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubcategoryId { get; set; }
        public decimal Price { get; set; }
        public SubCategory Subcategory { get; set; }
    }
}
