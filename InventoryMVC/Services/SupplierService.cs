using InventoryMVC.DTOs;
using InventoryMVC.Repositories.Interfaces;
using InventoryMVC.Services.Interfaces;
using InventoryMVC.Models;

namespace InventoryMVC.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }
        public void Create(CreateSupplierDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Supplier name cannot be empty.");
            }
            var supplier = new Supplier
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Address = dto.Address,
                Description = dto.Description
            };
            _repository.AddSupplier(supplier);
        }
        public List<Supplier> GetAll()
        {
            return _repository.GetAll();
        }
        public Supplier? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(UpdateSupplierDto dto)
        {
            var supplier = _repository.GetById(dto.Id);
            if (supplier == null)
            {
                throw new ArgumentException("Supplier not found.");
            }
            supplier.Name = dto.Name;
            supplier.PhoneNumber = dto.PhoneNumber;
            supplier.Email = dto.Email;
            supplier.Address = dto.Address;
            supplier.Description = dto.Description;
            _repository.UpdateSupplier(supplier);
        }
        public void Delete(int id)
        {
            var supplier = _repository.GetById(id);
            if (supplier == null)
            {
                throw new ArgumentException("Supplier not found.");
            }
            _repository.DeleteSupplier(supplier);
        }
    }
}
