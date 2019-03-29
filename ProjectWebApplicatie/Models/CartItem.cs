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
        public string ItemID { get; set; }

        public string CartID { get; set; }

        public int Quantity { get; set; }

        public System.DateTime TijdstipAangemaakt { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}