﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class Restaurant
    {
        public string RestaurantName { get; set; }
        public List<string> Keukens { get; set; }
    }
}