using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCue.Web.Models
{
    public class SmsTaskPayload
    {
        public string mobile { get; set; }
        public string message { get; set; }
    }
}