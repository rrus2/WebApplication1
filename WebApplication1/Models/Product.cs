﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public Product()
        {
            Orders = new List<Order>();
        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public List<Order> Orders { get; set; }
    }
}