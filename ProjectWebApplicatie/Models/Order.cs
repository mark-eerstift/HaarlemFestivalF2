using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Order
    {
        [Key]
        public virtual int OrderID { get; set; }

        public virtual string Email { get; set; }

        public virtual int TicketID { get; set; }
    }
}