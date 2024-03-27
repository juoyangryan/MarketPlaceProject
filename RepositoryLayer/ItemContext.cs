using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace RepositoryLayer
{
    public class ItemContext :DbContext

    {
        public ItemContext() : base("ItemContext")
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
