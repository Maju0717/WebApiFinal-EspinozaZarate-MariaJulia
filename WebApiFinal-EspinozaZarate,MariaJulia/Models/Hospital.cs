using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApiFinal_EspinozaZarate_MariaJulia.Models
{
    [Table("Hospital")]
    public class Hospital
    {
        [Key]
        [Required]
        public int Hospital_Cod { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Telefono { get; set; }

        public int? Num_Cama { get; set; }

        public List<Doctor> Doctors { get; set; }

    }
}
