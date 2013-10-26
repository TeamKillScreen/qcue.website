﻿using System;
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
    }
}
