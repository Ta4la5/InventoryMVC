using InventoryMVC.DTOs;
using InventoryMVC.Models;

namespace InventoryMVC.Services.Interfaces
{
    public interface ISupplierService
    {
        void Create(CreateSupplierDto dto);
        List<Supplier> GetAll();
        Supplier? GetById(int id);
        void Update(UpdateSupplierDto dto);
        public void Delete(int id);
    }
}
