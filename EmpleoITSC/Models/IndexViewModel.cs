using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Models
{
    public class IndexViewModel : Pagination
    {
        public List<USERS> Users { get; set; }
        public List<JOB> Jobs { get; set; }
        public List<APPLYJOB> ApplyJobs { get; set; }
        public List<GRADUATEPLUS> GradutePlus { get; set; }
        public List<MAILBOX> MailBoxs { get; set; }

    }
}
