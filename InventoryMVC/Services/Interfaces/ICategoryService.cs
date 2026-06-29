using InventoryMVC.DTOs;
using InventoryMVC.Models;

namespace InventoryMVC.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(CreateCategoryDto dto);
        List<Category> GetAll();
        Category? GetById(int id);
        void Update(UpdateCategoryDto dto);
        public void Delete(int id);
    }
}
