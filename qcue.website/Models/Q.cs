using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCue.Web.Models
{
    public class Q
    {
        public string queueId { get; set; }
        public string name { get; set; }
        public string shortCode { get; set; }

        public Dictionary<string, QUser> users { get; set; }
    }
}
