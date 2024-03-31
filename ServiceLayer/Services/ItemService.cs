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
        public async Task<IEnumerable<Item>> GetFilteredAsync(int? modelYearFrom = null, int? modelYearTo = null, string useType = null, decimal? powerFrom = null, decimal? powerTo = null, decimal? heightFrom = null, decimal? heightTo = null, decimal? weightFrom = null, decimal? weightTo = null, string subCategory = null)
        {
            return await _itemRepository.GetFilteredAsync(modelYearFrom, modelYearTo, useType, powerFrom, powerTo, heightFrom, heightTo, weightFrom, weightTo, subCategory);
        }
    }
}
