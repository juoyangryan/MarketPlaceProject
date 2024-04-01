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
        new Category{ID = 2,Name = "Furniture"}
    };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var subcategories = new List<SubCategory>
    {
        new SubCategory{ID = 1,CategoryID =1,Name="Phone"},
        new SubCategory{ID = 2,CategoryID =2,Name="Bed"},
         new SubCategory{ID = 3,CategoryID =1,Name="Fan"}
    };
            subcategories.ForEach(s => context.SubCategories.Add(s));
            context.SaveChanges();

            var items = new List<Item>
    {
        new Item{ID = 1,SubCategoryID = 1,Name="Iphone",Description="It is expensive", Price=899,Manufacturer = "Apple", ProductYear = 2023, Series = "Pro",Model = "15", UseType = "Personal", Application = "Portable", MountingLocation="None", Accessories = "With Charger", Power = 10,Height= 2, Weight = 2,ImageUrl = "~/Content/Images/phone1.jpg"  },
        new Item{ID = 2,SubCategoryID = 1,Name="Huawei mate",Description="It is not expensive", Price=499,Manufacturer = "Huawei", ProductYear = 2023 , Series = "Mate",Model = "6", UseType = "Personal", Application = "Portable", MountingLocation="None", Accessories = "With Charger", Power = 10,Height= 2, Weight = 2,ImageUrl = "~/Content/Images/phone2.jpg"},
        new Item{ID = 3,SubCategoryID = 2,Name="Soft Mattress",Description="It is soft and comfortable", Price=599,Manufacturer = "IKEA", ProductYear = 2019 , Series = "Premium",Model = "1012", UseType = "Home", Application = "Indoor", MountingLocation="Floor", Accessories = "With cover", Power = 0,Height= 100, Weight = 200,ImageUrl = "~/Content/Images/mattress1.jpg"},
        new Item{ID = 4,SubCategoryID = 3,Name="Big Ass fan 1",Description="It is big", Price=1599,Manufacturer = "Big Ass", ProductYear = 2016 , Series = "Premium",Model = "S3-150-S0-BC", UseType = "Commercial", Application = "Indoor", MountingLocation="Roof", Accessories = "With Light", Power = 19,Height= 31, Weight = 12,ImageUrl = "~/Content/Images/fan1.jpeg"},
        new Item{ID = 5,SubCategoryID = 3,Name="Big Ass fan 2",Description="It is super big", Price=1899,Manufacturer = "Big Ass", ProductYear = 2016 , Series = "Premium",Model = "S3-150-S0-BC", UseType = "Commercial", Application = "Indoor", MountingLocation="Roof", Accessories = "With Light", Power = 20,Height= 30, Weight = 13,ImageUrl = "~/Content/Images/fan1.jpeg"}
    };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }

    }
}
