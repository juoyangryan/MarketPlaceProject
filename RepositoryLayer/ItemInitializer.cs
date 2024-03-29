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
        new SubCategory{ID = 1,CategoryID =1,Name="Phone"}, // Note: Fixed typo CategroyID -> CategoryID
        new SubCategory{ID = 2,CategoryID =2,Name="Bed"}
    };
            subcategories.ForEach(s => context.SubCategories.Add(s));
            context.SaveChanges();

            var items = new List<Item>
    {
        new Item{ID = 1,SubCategoryID = 1,Name="Iphone",Description="It is expensive", Price=899,Manufacturer = "Apple", ProductYear = 2023},
        new Item{ID = 2,SubCategoryID = 1,Name="Huawei mate",Description="It is not expensive", Price=499,Manufacturer = "Huawei", ProductYear = 2023},
        new Item{ID = 3,SubCategoryID = 2,Name="Soft Mattress",Description="It is soft and comfortable", Price=599,Manufacturer = "IKEA", ProductYear = 2019},
    };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }

    }
}
