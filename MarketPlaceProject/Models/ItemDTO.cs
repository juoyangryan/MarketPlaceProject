using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlaceProject.Models
{
    public class ItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public decimal Power { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string ImageUrl { get; set; }
        public string sortOrder { get; set; }
    }
}