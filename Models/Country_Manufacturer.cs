using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Country_Manufacturer
    {
        [Key]
        public int idCountryManufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string? countryManufacturer { get; set; }

        public ICollection<Product>? products { get; set; }
    }
}
