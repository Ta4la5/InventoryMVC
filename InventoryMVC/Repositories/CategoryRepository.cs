using InventoryMVC.Data;
using InventoryMVC.Models;
using InventoryMVC.Repositories.Interfaces;

namespace InventoryMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            // Implementation for adding a category
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public List<Category> GetAll()
        {
            // Implementation for retrieving all categories
            return _context.Categories.ToList();
        }
        public Category? GetById(int id)
        {
            // Implementation for retrieving a category by ID
            return _context.Categories.Find(id);
        }
        public void UpdateCategory(Category category)
        {
            // Implementation for updating a category
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Delete(Category category)
        {
            // Implementation for deleting a category
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
