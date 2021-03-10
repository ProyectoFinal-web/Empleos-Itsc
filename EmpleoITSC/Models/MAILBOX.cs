using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleoITSC.Models
{
    [Table("MAILBOX")]
    public partial class MAILBOX
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int mailId { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Comentario")]
        public string comment { get; set; }

        public int? userId { get; set; }

        [StringLength(100)]
        public string dateStart { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [StringLength(500)]
        public string carrer { get; set; }

    }
}
