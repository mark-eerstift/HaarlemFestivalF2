using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Jazz : Evenement
    {
        public virtual string Stage { get; set; }
        public virtual Artiest Artiest { get; set; }
        public virtual Event Events { get; set; }


    }
}