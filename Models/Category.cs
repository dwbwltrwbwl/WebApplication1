using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int idCategory { get; set; }

        [Required]
        [StringLength(50)]
        public string? category { get; set; }

        public ICollection<Product>? products { get; set; }
    }
}
