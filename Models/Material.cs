using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Material
    {
        [Key]
        public int idMaterial { get; set; }

        [Required]
        [StringLength(50)]
        public string? material { get; set; }

        public ICollection<Product>? products { get; set; }
    }
}
