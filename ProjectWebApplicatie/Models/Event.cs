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
        public virtual string eventSoort { get; set; }
    }
}