using MachineAssignment.Models;
using MachineAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineAssignment.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categoryList = await _categoryServices.getAllCategoryList();

            return View(categoryList);
        }

        public async Task<IActionResult> AddCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            int categoryCount = await _categoryServices.AddCategoryData(category);
            if (categoryCount > 0)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            Category categoryItem = await _categoryServices.EditCategoryData(id);
            return View(categoryItem);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            int categoryCount = await _categoryServices.UpdateCategoryData(category);
            if (categoryCount > 0)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> CategoryDetails(int id)
        {
            Category categoryItem = await _categoryServices.CategoryData(id);
            return View(categoryItem);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category categoryItem = await _categoryServices.CategoryData(id);
            return View(categoryItem);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            int isDeleted = await _categoryServices.DeleteCategoryData(category);
            if (isDeleted > 0)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

    }
}
