using DomainLayer.Interfaces;
using DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _itemRepository.GetAllAsync();
        }
        public async Task<IEnumerable<Item>> GetBySubcategoryNameAsync(string subcategoryName)
        {
            return await _itemRepository.GetBySubcategoryNameAsync(subcategoryName);
        }

        public async Task AddAsync(Item item)
        {
            await _itemRepository.AddAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            await _itemRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _itemRepository.DeleteAsync(id);
        }
    }
}
