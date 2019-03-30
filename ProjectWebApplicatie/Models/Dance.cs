using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Dance : Evenement
    {
        public virtual string Session { get; set; }
        public virtual Artiest Artiest { get; set; }
        public virtual Event Event
        {
            get { return Event; }
            set { Event.EventSoort = "Dance"; }
        }
    }
}