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

        public int? userId { get; set; }

        public int? jobId { get; set; }
        
    }
}
