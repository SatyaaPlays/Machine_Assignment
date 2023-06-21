
using MachineAssignment.Models;

namespace MachineAssignment.Services
{
    public interface ICategoryServices
    {
        Task<int> AddCategoryData(Category category);
        Task<Category> CategoryData(int id);
        Task<int> DeleteCategoryData(Category category);
        Task<Category> EditCategoryData(int id);
        Task<List<Category>> getAllCategoryList();
        Task<int> UpdateCategoryData(Category category);
    }
}
