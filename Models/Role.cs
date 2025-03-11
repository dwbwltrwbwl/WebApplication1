using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Role
    {
        [Key]
        public int idRole { get; set; }

        [Required]
        [StringLength(50)]
        public string? role { get; set; }

        public ICollection<User>? users { get; set; }
    }
}
