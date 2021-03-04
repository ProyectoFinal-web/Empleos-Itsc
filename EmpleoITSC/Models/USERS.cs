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

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string userPass { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string lastName { get; set; }

        public string cv { get; set; }

        [Required]
        [StringLength(3)]
        public string rol { get; set; }

        [StringLength(500)]
        public string career { get; set; }

    }
}
