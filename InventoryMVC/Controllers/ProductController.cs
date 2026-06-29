using InventoryMVC.DTOs;
using InventoryMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        public ProductController(
            IProductService service, 
            ICategoryService categoryService,
            ISupplierService supplierService)
        {
            _service = service;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }
        public ActionResult Index()
        {
            var products = _service.GetAll();
            return View(products);
        }
        public IActionResult Edit(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Add()
        {
            var categories = _categoryService.GetAll();
            var suppliers = _supplierService.GetAll();

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name");
            ViewBag.Suppliers = new SelectList(
                suppliers,
                "Id",
                "Name");
            return View();
        }
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            TempData["Success"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Save(CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(
                    _categoryService.GetAll(),
                    "Id",
                    "Name");

                return View("Add", dto);
            }
            _service.Create(dto);
            TempData["Success"] = "Product created successfully!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(UpdateProductDto dto)
        {
            _service.Update(dto);
            TempData["Success"] = "Product updated successfully!";
            return RedirectToAction("Index");
        }
        
    }
}
