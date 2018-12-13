using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class EventPage
    {
        public virtual string[] Teksten { get; set; }
        public virtual List<Image> Afbeeldingen { get; set; }
    }
}