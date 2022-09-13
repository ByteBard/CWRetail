﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
    }
}