using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApplicatie.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime TijdstipAangemaakt { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}