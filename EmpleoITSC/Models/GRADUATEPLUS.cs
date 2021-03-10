using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleoITSC.Models
{
    public partial class GRADUATEPLUS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gradId { get; set;}

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(300)]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Descripcion")]
        public string descriptionGrad { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Carrera")]
        [StringLength(500)]
        public string career { get; set; }

        public byte[] photo { get; set; }
    }
}
