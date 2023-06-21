using MachineAssignment.Models;

namespace MachineAssignment.Repository
{
    public interface IProductRepository
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
