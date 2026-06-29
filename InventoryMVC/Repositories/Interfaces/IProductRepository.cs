using InventoryMVC.Models;

namespace InventoryMVC.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetAll();
        Product? GetById(int id);
        void Update(Product product);
        void Delete(Product product);
    }
}
