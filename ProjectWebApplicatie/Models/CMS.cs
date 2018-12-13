using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class CMS
    {
        public virtual List<Vrijwilliger> Vrijwilligers { get; set; }

        public void AddEvent() { }
        public void RemoveEvent() { }
        public void EditEvent() { }
        public void GetSales() { }
        public void ResetPassword(Vrijwilliger vrijwilliger) { }
        public void EditEventPage() { }
    }
}