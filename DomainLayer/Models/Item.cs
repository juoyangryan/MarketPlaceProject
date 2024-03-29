using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int ProductYear { get; set; }
        public string UseType { get; set; }
        public string Application { get; set; }
        public string MountingLocation { get; set; }
        public string Accessories { get; set; }
       
        public decimal Power { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string ImageUrl { get; set; }
        // Foreign key
        public int SubCategoryID { get; set; }

        // Navigation property to SubCategory
        public virtual SubCategory SubCategories { get; set; }
    }
}
