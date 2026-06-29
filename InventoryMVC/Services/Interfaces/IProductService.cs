using InventoryMVC.DTOs;
using InventoryMVC.Models;

namespace InventoryMVC.Services.Interfaces
{
    public interface IProductService
    {
        void Create(CreateProductDto dto);
        List<Product> GetAll();
        Product GetById(int id);
        void Update(UpdateProductDto dto);
        void Delete(int id);
    }
}
