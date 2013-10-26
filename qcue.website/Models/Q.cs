using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCue.Web.Models
{
    public class Q
    {
        public string ShortCode { get; set; }
        public Dictionary<string, QUser> Users { get; set; }
    }
}
