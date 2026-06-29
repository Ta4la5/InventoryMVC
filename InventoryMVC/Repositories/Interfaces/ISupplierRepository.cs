using InventoryMVC.Models;

namespace InventoryMVC.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        void AddSupplier(Supplier supplier);
        List<Supplier> GetAll();
        Supplier? GetById(int id);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
