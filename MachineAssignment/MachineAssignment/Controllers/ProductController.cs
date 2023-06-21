using MachineAssignment.Models;
using MachineAssignment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineAssignment.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> GetAllProducts()
        {
            List<Products> productList = await _productService.GetProductList();
            return View(productList);
        }

        public async Task<IActionResult> AddProduct()
        {
            var category = await _productService.GetCategoryName();
            ViewBag.Category = new SelectList(category,"Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Products product)
        {
            int productCount = await _productService.AddProductData(product);
            if (productCount > 0)
            {
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var category = await _productService.GetCategoryName();
            ViewBag.Category = new SelectList(category, "Id", "CategoryName");
            Products productItem = await _productService.EditProductData(id);
            return View(productItem);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Products product)
        {
            int productCount = await _productService.UpdateProductData(product);
            if (productCount > 0)
            {
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            Products productItem = await _productService.ProductData(id);
            return View(productItem);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            Products productItem = await _productService.ProductData(id);
            return View(productItem);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Products product)
        {
            int isDeleted = await _productService.DeleteProductData(product);
            if (isDeleted > 0)
            {
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }
    }
}
