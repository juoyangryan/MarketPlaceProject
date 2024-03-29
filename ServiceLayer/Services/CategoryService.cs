﻿using DomainLayer.Interfaces;
using DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
