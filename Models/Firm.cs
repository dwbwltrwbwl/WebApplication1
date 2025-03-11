using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Firm
    {
        [Key]
        public int idFirm { get; set; }

        [Required]
        [StringLength(50)]
        public string? firm { get; set; }

        public ICollection<Product>? products { get; set; }
    }
}
