using InventoryMVC.DTOs;
using InventoryMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }
        public IActionResult Edit(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _service.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            TempData["SuccessMessage"] = "Category deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();
        }

        // Displays the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // Saves the category
        [HttpPost]
        public IActionResult Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", dto);
            }
            //else if (string.IsNullOrWhiteSpace(dto.Name))
            //{
            //    ModelState.AddModelError("Name", "The Name field is required.");
            //    return View(dto);
            //}
            //else
            //{
            //    // Check if the category name already exists
            //    var existingCategory = _service.GetAll().FirstOrDefault(c => c.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));
            //    if (existingCategory != null)
            //    {
            //        ModelState.AddModelError("Name", "A category with this name already exists.");
            //        return View(dto);
            //    }
            //}

            _service.Create(dto);

            TempData["SuccessMessage"] = "Category created successfully!";

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", dto);
            }
            _service.Update(dto);
            TempData["SuccessMessage"] = "Category updated successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}