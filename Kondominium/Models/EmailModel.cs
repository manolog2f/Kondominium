using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kondominium.Models
{
    public class EmailModel
    {
        
        public string TO { get; set; }
        public string Cc { get; set; }
        public string Cco { get; set; }
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

    }
}