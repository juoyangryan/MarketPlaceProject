using DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<SubCategory> GetByIdAsync(int id);
        Task<IEnumerable<SubCategory>> GetAllAsync();
        Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId);
        Task AddAsync(SubCategory subcategory);
        Task UpdateAsync(SubCategory subcategory);
        Task DeleteAsync(int id);
    }
}
