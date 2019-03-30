﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Food : Evenement
    {
        public virtual Restaurant Restaurant { get; set; }
        public virtual Event Event
        {
            get { return Event; }
            set { Event.EventSoort = "Food"; }
        }
    }
}