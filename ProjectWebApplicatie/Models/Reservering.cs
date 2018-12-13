using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Reservering : Ticket
    {
        public virtual string Notitie { get; set; }

        public void NotitieMaken()
        {

        }
    }
}