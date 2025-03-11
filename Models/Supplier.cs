using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Supplier
    {
        [Key]
        public int idSupplier { get; set; }

        [Required]
        [StringLength(50)]
        public string? supplier { get; set; }

        public ICollection<Product>? products { get; set; }
    }
}
