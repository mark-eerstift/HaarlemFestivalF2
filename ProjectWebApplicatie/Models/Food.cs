using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Food : Evenement
    {
        public virtual Restaurant Restaurant { get; set; }

        
    }
}