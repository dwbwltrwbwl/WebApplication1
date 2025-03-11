using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }

        public int idCategory { get; set; }
        [ForeignKey("idCategory")]
        public Category? Category { get; set; }

        public int idFirm { get; set; }
        [ForeignKey("idFirm")]
        public Firm? Firm { get; set; }

        public int idSupplier { get; set; }
        [ForeignKey("idSupplier")]
        public Supplier? Supplier { get; set; }

        public int idMaterial { get; set; }
        [ForeignKey("idMaterial")]
        public Material? Material { get; set; }

        public int idCountryManufacturer { get; set; }
        [ForeignKey("idCountryManufacturer")]
        public Country_Manufacturer? Country_Manufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string? productName { get; set; }

        public decimal Price { get; set; }
    }
}
