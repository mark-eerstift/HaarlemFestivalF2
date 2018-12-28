using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApplicatie.Models
{
    public class Event
    {
        [Key]
        public virtual int EventId { get; set; }
        public virtual string EventSoort { get; set; }
        public virtual List<EventPage> EventPages { get; set;}
    }
}