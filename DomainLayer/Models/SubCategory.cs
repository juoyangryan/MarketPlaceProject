using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class SubCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Foreign Key
        public int CategoryID { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual Category Category { get; set; }
             
    }
}
