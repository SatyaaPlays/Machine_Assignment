using MachineAssignment.Models;
using MachineAssignment.Repository;

namespace MachineAssignment.Services
{
    public class CategoryServices : ICategoryServices
    {
        readonly ICategoryRepository _categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddCategoryData(Category category)
        {
            return await _categoryRepository.AddCategoryData(category);
        }

        public async Task<Category> CategoryData(int id)
        {
            return await _categoryRepository.CategoryData(id);
        }

        public async Task<int> DeleteCategoryData(Category category)
        {
            return await _categoryRepository.DeleteCategoryData(category);
        }

        public async Task<Category> EditCategoryData(int id)
        {
            return await _categoryRepository.EditCategoryData(id);
        }

        public async Task<List<Category>> getAllCategoryList()
        {
            return await _categoryRepository.getAllCategoryList();
        }

        public async Task<int> UpdateCategoryData(Category category)
        {
            return await _categoryRepository.UpdateCategoryData(category);
        }
    }
}
