using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApplicatie.Models
{
    public class Ticket
    {
        [Key]
        public virtual int TicketID { get; set; }
        public virtual Event Event { get; set; }
        public virtual float Prijs { get; set; }
        public virtual bool SaleStatus { get; set; }

        public void IsVerkocht()
        {

        }
    }
}