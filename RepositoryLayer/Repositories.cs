using System;
using System.Collections.Generic;
using System.Data.Entity; // If you're using EF 6. For EF Core, use Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
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

        public async Task<IEnumerable<Item>> GetFilteredAsync(int? modelYearFrom = null, int? modelYearTo = null, string useType = null, decimal? powerFrom = null, decimal? powerTo = null, decimal? heightFrom = null, decimal? heightTo = null, decimal? weightFrom = null, decimal? weightTo = null, string subcategoryName = null, string sortOrder =null)
        {
            var query = _context.Items.AsQueryable();

            if (modelYearFrom.HasValue)
                query = query.Where(item => item.ProductYear >= modelYearFrom.Value);

            if (modelYearTo.HasValue)
                query = query.Where(item => item.ProductYear <= modelYearTo.Value);

            if (!string.IsNullOrWhiteSpace(useType))
                query = query.Where(item => item.UseType.Equals(useType, StringComparison.OrdinalIgnoreCase));

            if (powerFrom.HasValue)
                query = query.Where(item => item.Power >= powerFrom.Value);

            if (powerTo.HasValue)
                query = query.Where(item => item.Power <= powerTo.Value);

            if (heightFrom.HasValue)
                query = query.Where(item => item.Height >= heightFrom.Value);

            if (heightTo.HasValue)
                query = query.Where(item => item.Height <= heightTo.Value);

            if (weightFrom.HasValue)
                query = query.Where(item => item.Weight >= weightFrom.Value);

            if (weightTo.HasValue)
                query = query.Where(item => item.Weight <= weightTo.Value);

            // Filter by subcategoryName if provided
            if (!string.IsNullOrWhiteSpace(subcategoryName))
            {
                query = query.Where(item => item.SubCategories.Name.Equals(subcategoryName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(sortOrder))
            {
                switch (sortOrder)
                {
                    case "weightAsc":
                        query = query.OrderBy(item => item.Weight);
                        break;
                    case "weightDesc":
                        query = query.OrderByDescending(item => item.Weight);
                        break;
                    case "heightAsc":
                        query = query.OrderBy(item => item.Height);
                        break;
                    case "heightDesc":
                        query = query.OrderByDescending(item => item.Height);
                        break;
                    case "powerAsc":
                        query = query.OrderBy(item => item.Power);
                        break;
                    case "powerDesc":
                        query = query.OrderByDescending(item => item.Power);
                        break;
                }
            }

            return await query.ToListAsync();
        }


        public async Task<IEnumerable<Item>> GetByIdListAsync(int[] ids)
        {
            return await _context.Items.Where(item => ids.Contains(item.ID)).ToListAsync();
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

    public class UserRepository: IUserRepository
    {
        private readonly ItemContext _context;

        public UserRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserDTO> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(y => y.Email == email);
        }

        public async Task AddUser(UserDTO userDTO)
        {
            _context.Users.Add(userDTO);
            await _context.SaveChangesAsync();
        }
    }
}
