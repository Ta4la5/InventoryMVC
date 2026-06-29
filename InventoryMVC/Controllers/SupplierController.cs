using InventoryMVC.DTOs;
using InventoryMVC.Services;
using InventoryMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryMVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _service;
        public SupplierController(ISupplierService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var suppliers = _service.GetAll();
            return View(suppliers);
        }
        public IActionResult Edit(int id)
        {
            var supplier = _service.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        public IActionResult Delete(int id)
        {
            var supplier = _service.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            TempData["SuccessMessage"] = "Supplier deleted successfully!";
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(CreateSupplierDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            _service.Create(dto);
            TempData["SuccessMessage"] = "Supplier created successfully!";
            return RedirectToAction("Index");
        }
        public IActionResult Update(UpdateSupplierDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", dto);
            }
            _service.Update(dto);
            TempData["SuccessMessage"] = "Supplier updated successfully!";
            return RedirectToAction("Index");
        }
    }
}
