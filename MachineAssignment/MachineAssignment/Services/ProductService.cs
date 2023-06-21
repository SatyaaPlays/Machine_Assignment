using MachineAssignment.Models;
using MachineAssignment.Repository;

namespace MachineAssignment.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddProductData(Products product)
        {
            return await _productRepository.AddProductData(product);
        }

        public async Task<int> DeleteProductData(Products product)
        {
            return await _productRepository.DeleteProductData(product);
        }

        public async Task<Products> EditProductData(int id)
        {
            return await _productRepository.EditProductData(id);
        }

        public async Task<List<Category>> GetCategoryName()
        {
            return await _productRepository.GetCategoryName();
        }

        public async Task<List<Products>> GetProductList()
        {
            return await _productRepository.GetProductList();
        }

        public async Task<Products> ProductData(int id)
        {
            return await _productRepository.ProductData(id);
        }

        public async Task<int> UpdateProductData(Products product)
        {
            return await _productRepository.UpdateProductData(product);
        }
    }
}
