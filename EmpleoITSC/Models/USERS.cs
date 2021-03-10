using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleoITSC.Models
{
    public partial class USERS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(50)]
        [Display(Name="Matricula")]
        public string userName { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string userPass { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(100)]
        [Display(Name = "Apellido")]
        public string lastName { get; set; }

        [Display(Name = "Curriculum")]
        public byte[] cv { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Tipo de usuario")]
        public string rol { get; set; }

        [StringLength(500)]
        [Display(Name = "Carrera")]
        public string career { get; set; }

        public string cvName { get; set; }

    }
}
