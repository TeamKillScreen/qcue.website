using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCue.Web.Models
{
    public class SmsTask : ITask
    {
        public string smsTaskId { get; set; }
        public string task { get; set; }
        public SmsTaskPayload payload { get; set; }
    }
}
