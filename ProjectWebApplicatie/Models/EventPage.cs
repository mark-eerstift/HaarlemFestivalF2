using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApplicatie.Models
{
    public class EventPage
    {
        [Key]
        public virtual int EventPageID { get; set; }
        public virtual List<string> Teksten { get; set; }
        public virtual List<Image> Afbeeldingen { get; set; }

        public void ChangeLanguage() { }
    }
}