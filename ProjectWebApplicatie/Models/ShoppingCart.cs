using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class ShoppingCart
    {
        public virtual List<Ticket> TicketsInCart { get; set; }

        public void Afrekenen() { }
    }
}