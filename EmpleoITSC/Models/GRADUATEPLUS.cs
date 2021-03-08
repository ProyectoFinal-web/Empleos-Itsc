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

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        [Required]
        public string descriptionGrad { get; set; }

        [Required]
        [StringLength(500)]
        public string career { get; set; }

        public byte[] photo { get; set; }
    }
}
