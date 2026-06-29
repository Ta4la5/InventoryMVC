using InventoryMVC.DTOs;
using InventoryMVC.Models;
using InventoryMVC.Repositories.Interfaces;
using InventoryMVC.Services.Interfaces;

namespace InventoryMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
            _repository.AddCategory(category);
        }
        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }
        public Category? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(UpdateCategoryDto dto)
        {
            var category = _repository.GetById(dto.Id);
            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }
            category.Name = dto.Name;
            category.Description = dto.Description;
            _repository.UpdateCategory(category);
        }
        public void Delete(int id)
        {     
            var category = _repository.GetById(id);
            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }
            _repository.Delete(category);
        }
    }
}
