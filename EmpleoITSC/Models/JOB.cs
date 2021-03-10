using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleoITSC.Models
{
    [Table("JOB")]
    public partial class JOB
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int jobId { get; set; }

        [Required(ErrorMessage ="El campo {0} es necesario")]
        [StringLength(500)]
        [Display(Name ="Puesto")]
        public string title { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Descripcion del Puesto")]
        public string descriptionJob { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Requisitos")]
        public string requirements { get; set; }

        public string dateStart { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(500)]
        [Display(Name = "Nombre de la Empresa")]
        public string companyName { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(500)]
        [Display(Name = "Direccion de la Empresa")]
        public string companyAdress { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(100)]
        [Display(Name = "Horario")]
        public string schedule { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(100)]
        [Display(Name = "Tipo de Contracto")]
        public string contractJob { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(100)]
        [Display(Name = "Modalidad")]
        public string modality { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Carrera")]
        public string career { get; set; }
    }
}
