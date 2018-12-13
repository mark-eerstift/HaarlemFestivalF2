using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class DayAllPassTicket : Ticket
    {
        public virtual DateTime Date { get; set; }
    }
}