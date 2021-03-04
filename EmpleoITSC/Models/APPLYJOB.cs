using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleoITSC.Models
{
    [Table("APPLYJOB")]
    public partial class APPLYJOB
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int applyId { get; set; }

        [StringLength(15)]
        public string userId { get; set; }

        [StringLength(14)]
        public string jobId { get; set; }
    }
}
