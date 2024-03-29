using DomainLayer.Interfaces;
using DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subcategoryRepository;

        public SubCategoryService(ISubCategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            return await _subcategoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return await _subcategoryRepository.GetAllAsync();
        }

        // Implement the new method
        public async Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _subcategoryRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task AddAsync(SubCategory subcategory)
        {
            await _subcategoryRepository.AddAsync(subcategory);
        }

        public async Task UpdateAsync(SubCategory subcategory)
        {
            await _subcategoryRepository.UpdateAsync(subcategory);
        }

        public async Task DeleteAsync(int id)
        {
            await _subcategoryRepository.DeleteAsync(id);
        }
    }
}
