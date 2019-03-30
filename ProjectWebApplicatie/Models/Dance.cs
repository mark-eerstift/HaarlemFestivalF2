using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Dance : Evenement
    {
        public string eventsoort;
        public virtual string Session { get; set; }
        public virtual Artiest Artiest { get; set; }
        Event eventding = new Event
        {
            EventSoort = "Dance",
            
        };



    }
}