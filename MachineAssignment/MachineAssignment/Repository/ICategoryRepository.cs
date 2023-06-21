using MachineAssignment.Models;

namespace MachineAssignment.Repository
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryData(Category category);
        Task<Category> CategoryData(int id);
        Task<int> DeleteCategoryData(Category category);
        Task<Category> EditCategoryData(int id);
        Task<List<Category>> getAllCategoryList();
        Task<int> UpdateCategoryData(Category category);
    }
}
