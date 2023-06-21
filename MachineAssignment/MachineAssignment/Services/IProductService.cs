using MachineAssignment.Models;

namespace MachineAssignment.Services
{
    public interface IProductService
    {
        Task<int> AddProductData(Products product);
        Task<int> DeleteProductData(Products product);
        Task<Products> EditProductData(int id);
        Task<List<Category>> GetCategoryName();
        Task<List<Products>> GetProductList();
        Task<Products> ProductData(int id);
        Task<int> UpdateProductData(Products product);
    }
}
