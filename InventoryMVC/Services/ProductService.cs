using InventoryMVC.DTOs;
using InventoryMVC.Models;
using InventoryMVC.Repositories.Interfaces;
using InventoryMVC.Services.Interfaces;

namespace InventoryMVC.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateProductDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId,
                UnitPrice = dto.UnitPrice,
                QuantityInStock = dto.QuantityInStock
            };

            _repository.Add(product);
        }
        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }
        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(UpdateProductDto dto)
        {
            var product = _repository.GetById(dto.Id);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;
            product.UnitPrice = dto.UnitPrice;
            product.QuantityInStock = dto.QuantityInStock;
            _repository.Update(product);
        }
        public void Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }
            _repository.Delete(product);
        }
    }
}