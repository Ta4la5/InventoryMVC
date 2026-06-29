using InventoryMVC.Models;

namespace InventoryMVC.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        List<Category> GetAll();
        Category? GetById(int id);
        void UpdateCategory(Category category);
        void Delete(Category category);
    }
}
