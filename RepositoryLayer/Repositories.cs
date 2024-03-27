using System.Collections.Generic;
using System.Data.Entity; // If you're using EF 6. For EF Core, use Microsoft.EntityFrameworkCore;
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

        // Implement other methods as needed
    }
}
