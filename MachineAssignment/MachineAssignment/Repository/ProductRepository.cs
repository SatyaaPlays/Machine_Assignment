using MachineAssignment.Context;
using MachineAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineAssignment.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> AddProductData(Products product)
        {
            await _applicationDbContext.tbl_Products.AddAsync(product);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductData(Products product)
        {
            _applicationDbContext.tbl_Products.Remove(product);
            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Products> EditProductData(int id)
        {
            return await _applicationDbContext.tbl_Products.Include(cat => cat.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Category>> GetCategoryName()
        {
            return await _applicationDbContext.tbl_mstCategory.ToListAsync();
        }

        public async Task<List<Products>> GetProductList()
        {
            return await _applicationDbContext.tbl_Products.Include(cat => cat.Category).ToListAsync();
        }

        public async Task<Products> ProductData(int id)
        {
            return await _applicationDbContext.tbl_Products.Include(cat => cat.Category).SingleOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<int> UpdateProductData(Products product)
        {
            _applicationDbContext.tbl_Products.Update(product);
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
