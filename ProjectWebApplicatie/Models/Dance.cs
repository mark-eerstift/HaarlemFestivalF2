using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Dance : Evenement
    {
        public virtual string Stage { get; set; }
        public virtual Artiest Artiest { get; set; }
    }
}