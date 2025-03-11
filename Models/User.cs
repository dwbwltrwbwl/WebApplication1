using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }

        [StringLength(50)]
        public string? lastName { get; set; }

        [StringLength(50)]
        public string? firstName { get; set; }

        [StringLength(50)]
        public string? middleName { get; set; }

        [StringLength(50)]
        public string? email { get; set; }

        [StringLength(50)]
        public string? login { get; set; }

        [StringLength(50)]
        public string? password { get; set; }

        public int idRole { get; set; }
        [ForeignKey("idRole")]
        public Role? Role { get; set; }
    }
}
