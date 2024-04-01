using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainLayer.Models;

namespace RepositoryLayer
{
    internal class ItemInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ItemContext>
    {
        protected override void Seed(ItemContext context)
        {
            var categories = new List<Category>
    {
        new Category{ID = 1,Name = "Electronic"},
        new Category{ID = 2,Name = "Furniture"}, 
        new Category {ID = 3, Name = "Stationary"}, 
        new Category{ID = 4, Name = "Mechanical"}
    };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var subcategories = new List<SubCategory>
    {
        new SubCategory{ID = 1,CategoryID =1,Name="Phone"},
        new SubCategory{ID = 2,CategoryID =2,Name="Bed"},
         new SubCategory{ID = 3,CategoryID =1,Name="Fan"}, 
         new SubCategory{ID = 4, CategoryID = 3, Name = "Scissors"},
         new SubCategory{ID = 5, CategoryID = 3, Name = "Pencil"}, 
         new SubCategory {ID = 6, CategoryID = 4, Name = "Powerdrill"},
         new SubCategory{ID = 7, CategoryID = 4, Name = "Circular Saw"}
    };
            subcategories.ForEach(s => context.SubCategories.Add(s));
            context.SaveChanges();

            var items = new List<Item>
    {
        new Item{ID = 1,SubCategoryID = 1,Name="Iphone",Description="It is expensive", Price=899,Manufacturer = "Apple", ProductYear = 2023, Series = "Pro",Model = "15", UseType = "Residential", Application = "Portable", MountingLocation="None", Accessories = "With Charger", Power = 10,Height= 2, Weight = 2,ImageUrl = "~/Content/Images/phone1.jpg"  },
        new Item{ID = 2,SubCategoryID = 1,Name="Huawei mate",Description="It is not expensive", Price=499,Manufacturer = "Huawei", ProductYear = 2023 , Series = "Mate",Model = "6", UseType = "Residential", Application = "Portable", MountingLocation="None", Accessories = "With Charger", Power = 10,Height= 2, Weight = 2,ImageUrl = "~/Content/Images/phone2.jpg"},
        new Item{ID = 3,SubCategoryID = 2,Name="Soft Mattress",Description="It is soft and comfortable", Price=599,Manufacturer = "IKEA", ProductYear = 2019 , Series = "Premium",Model = "1012", UseType = "Residential", Application = "Indoor", MountingLocation="Floor", Accessories = "With cover", Power = 0,Height= 100, Weight = 200,ImageUrl = "~/Content/Images/mattress1.jpg"},
        new Item{ID = 4,SubCategoryID = 3,Name="Big Ass fan 1",Description="It is big", Price=1599,Manufacturer = "Big Ass", ProductYear = 2016 , Series = "Premium",Model = "S3-150-S0-BC", UseType = "Commercial", Application = "Indoor", MountingLocation="Roof", Accessories = "With Light", Power = 20,Height= 30, Weight = 13,ImageUrl = "~/Content/Images/fan1.jpeg"},
        new Item{ID = 5,SubCategoryID = 3,Name="Sofucor fan",Description="Farmhouse Ceiling Fan", Price=149, Manufacturer = "Sofucor", ProductYear = 2020 , Series = "Farmhouse",Model = "Sofucor 52", UseType = "Residential", Application = "Indoor", MountingLocation="Ceiling", Accessories = "With Light", Power = 45,Height= 12, Weight = 150,ImageUrl = "~/Content/Images/fan2.jpeg"},
        new Item{ID = 6,SubCategoryID = 3,Name="Heavy Duty Tilt Drum Fan",Description="This Commercial Electric 24 in. heavy-duty tilt drum fan is ideal for spot ventilation in factories, garages, basements, warehouses and anywhere people and machines need to be kept cool. Made with a powerful motor and 2-speed switch, this heavy-duty drum fan lets you optimize air output depending on your needs. Featuring a 180° adjustable tilt, this heavy-duty drum fan can be adjusted to direct airflow exactly where you need it. 2-wheels and sturdy handle allow positioning of the floor fan exactly where you need it or easy transportation from one location to another. Cord wrap for convenient storage.", Price=149, Manufacturer = "Commercial Electric", ProductYear = 2018 , Series = "319343391",Model = "SFDC6-600CT0-4", UseType = "Industrial", Application = "Indoor", MountingLocation="Floor", Accessories = "N/A", Power = 271,Height= 29.92m, Weight = 29.43m, ImageUrl = "~/Content/Images/fan3.jpeg"},
        new Item{ID = 7,SubCategoryID = 3,Name="Hugger 52 in. LED Indoor Black Ceiling Fan with Light Kit",Description="Cool off your space with this Hugger 52 in. LED Indoor Black Ceiling Fan with Light Kit.", Price=60, Manufacturer = "Hugger", ProductYear = 2018 , Series = "301162049",Model = "AL383LED-BK", UseType = "Residential", Application = "Indoor", MountingLocation="Ceiling", Accessories = "With Light", Power = 240,Height= 11.8m, Weight = 13.68m, ImageUrl = "~/Content/Images/fan4.jpeg"}
    };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }

    }
}
