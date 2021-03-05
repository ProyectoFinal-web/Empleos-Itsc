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

        [Required]
        [StringLength(500)]
        public string title { get; set; }

        [Required]
        public string descriptionJob { get; set; }

        [Required]
        public string requirements { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateStart { get; set; }

        [Required]
        [StringLength(500)]
        public string companyName { get; set; }

        [Required]
        [StringLength(500)]
        public string companyAdress { get; set; }

        [Required]
        [StringLength(100)]
        public string schedule { get; set; }

        [StringLength(100)]
        public string contractJob { get; set; }

        [StringLength(100)]
        public string modality { get; set; }

        public string career { get; set; }
    }
}
