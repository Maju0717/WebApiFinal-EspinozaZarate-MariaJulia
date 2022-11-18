using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiFinal_EspinozaZarate_MariaJulia.Models
{
    [Table("Doctor#")]
    public class Doctor
    {
        [Key]
        [Required]
        public int Doctor_No { get; set; }

        [Required]
        public int Hospital_Cod { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Especialidad { get; set; }

        [ForeignKey("Hospital_Cod")]
        public Hospital Hospital { get; set; }


    }
}
