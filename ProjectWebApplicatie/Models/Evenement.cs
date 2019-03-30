using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApplicatie.Models
{
    public class Evenement
    {
        [Key]
        public virtual int EvenementID { get; set; }
        public virtual List<Ticket> AvailableTickets { get; set; }
        public virtual string Locatie { get; set; }
        public virtual DateTime BeginTijd { get; set; }
        public virtual DateTime EindTijd { get; set; }
        public virtual int TicketsTotaal { get; set; }
        public virtual int TicketsVerkocht { get; set; }
        public virtual double EvenementPrijs { get; set; }
        public virtual Event Event { get; set; }

    }
}