using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ProjectWebApplicatie.Models
{
    public class Vrijwilliger
    {
        [Key]
        public virtual int UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Wachtwoord { get; set; }
        public virtual String salt { get; set; }

        public void LogIn() { }
        public void LogUit() { }
    }
}