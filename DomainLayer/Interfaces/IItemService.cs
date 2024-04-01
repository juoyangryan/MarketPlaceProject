using DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IItemService
    {
        Task<Item> GetByIdAsync(int id);
        Task<IEnumerable<Item>> GetAllAsync();
        Task<IEnumerable<Item>> GetBySubcategoryNameAsync(string subcategoryName);
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(int id);
        Task<IEnumerable<Item>> GetByIdListAsync(int[] ids);

        Task<IEnumerable<Item>> GetFilteredAsync(int? modelYearFrom = null, int? modelYearTo = null, string useType = null, decimal? powerFrom = null, decimal? powerTo = null, decimal? heightFrom = null, decimal? heightTo = null, decimal? weightFrom = null, decimal? weightTo = null,string subCategory = null, string sortOrder = null);
    }
}
