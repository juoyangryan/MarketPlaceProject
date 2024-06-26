﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlaceProject.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Manufacture { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string UseType { get; set; }
        public string Application { get; set; }
        public string MountingLocation { get; set; }
        public string Accessories { get; set; }
        public int ModelYear { get; set; }
        public decimal Power { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string ImageUrl { get; set; }
    }
}