using MachineAssignment.Context;
using MachineAssignment.Models;
using MessagePack.Formatters;
using Microsoft.EntityFrameworkCore;

namespace MachineAssignment.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> AddCategoryData(Category category)
        {
            await _applicationDbContext.tbl_mstCategory.AddAsync(category);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Category> CategoryData(int id)
        {
            return await _applicationDbContext.tbl_mstCategory.FindAsync(id);
        }

        public async Task<int> DeleteCategoryData(Category category)
        {
            _applicationDbContext.tbl_mstCategory.Remove(category);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Category> EditCategoryData(int id)
        {
            return await _applicationDbContext.tbl_mstCategory.FindAsync(id);
        }

        public async Task<List<Category>> getAllCategoryList()
        {
            return await _applicationDbContext.tbl_mstCategory.ToListAsync();
        }

        public async Task<int> UpdateCategoryData(Category category)
        {
            _applicationDbContext.tbl_mstCategory.Update(category);
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
