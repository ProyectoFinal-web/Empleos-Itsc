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

        [Required]
        public string comment { get; set; }

        [StringLength(15)]
        public string userId { get; set; }
    }
}
