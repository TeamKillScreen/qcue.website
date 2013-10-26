using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QCue.Web.Models
{
    public class IncomingSmsMessage
    {
        [Required]
        public string Msg_Id { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string Content { get; set; }

        public override string ToString()
        {
            string format = "Msg_Id = \"{0}\", To = \"{1}\", From = \"{2}\", Content = \"{3}\"";

            return String.Format(
                format, this.Msg_Id, this.To, this.From, this.Content);
        }
    }
}
