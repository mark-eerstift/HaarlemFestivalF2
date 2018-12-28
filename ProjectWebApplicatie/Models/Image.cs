using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebApplicatie.Models
{
    public class Image
    {
        [Key]
        public virtual int ImageID { get; set; }
        public virtual string Name { get; set; }
    }
}