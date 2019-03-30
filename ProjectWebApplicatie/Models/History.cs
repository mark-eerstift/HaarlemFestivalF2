using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class History : Evenement
    {
        public virtual string EindLocatie { get; set; }
        public virtual string Taal { get; set; }
       
    }
}