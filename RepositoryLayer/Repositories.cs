using System;
using System.Collections.Generic;
using System.Data.Entity; // If you're using EF 6. For EF Core, use Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Interfaces;
using DomainLayer.Models;

namespace RepositoryLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            // For EF Core, use _context.Items.FindAsync(id)
            return await _context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            // For EF Core, use _context.Items.ToListAsync()
            return await _context.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetBySubcategoryNameAsync(string subcategoryName)
        {
            return await _context.Items
                                 .Where(item => item.SubCategories.Name.Equals(subcategoryName, StringComparison.OrdinalIgnoreCase))
                                 .ToListAsync();
        }



        public async Task AddAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Entry(item).State = EntityState.Modified; // For EF Core, this approach works directly
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

       
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ItemContext _context;

        public CategoryRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            // For EF Core, use _context.Items.FindAsync(id)
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            // For EF Core, use _context.Items.ToListAsync()
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified; // For EF Core, this approach works directly
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }


    }

    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ItemContext _context;

        public SubCategoryRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            // For EF Core, use _context.Items.FindAsync(id)
            return await _context.SubCategories.FindAsync(id);
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            // For EF Core, use _context.Items.ToListAsync()
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.SubCategories
                                 .Where(sc => sc.CategoryID == categoryId)
                                 .ToListAsync();
        }


        public async Task AddAsync(SubCategory subcategory)
        {
            _context.SubCategories.Add(subcategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory subcategory)
        {
            _context.Entry(subcategory).State = EntityState.Modified; // For EF Core, this approach works directly
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subcategory = await _context.SubCategories.FindAsync(id);
            if (subcategory != null)
            {
                _context.SubCategories.Remove(subcategory);
                await _context.SaveChangesAsync();
            }
        }


    }
}
