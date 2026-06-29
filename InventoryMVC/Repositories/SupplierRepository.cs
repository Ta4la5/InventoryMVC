using InventoryMVC.Data;
using InventoryMVC.Models;
using InventoryMVC.Repositories.Interfaces;

namespace InventoryMVC.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddSupplier(Supplier supplier)
        {
            // Implementation for adding a supplier
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }
        public List<Supplier> GetAll()
        {
            // Implementation for retrieving all suppliers
            return _context.Suppliers.ToList();
        }
        public Supplier? GetById(int id)
        {
            // Implementation for retrieving a supplier by ID
            return _context.Suppliers.Find(id);
        }
        public void UpdateSupplier(Supplier supplier)
        {
            // Implementation for updating a supplier
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }
        public void DeleteSupplier(Supplier supplier)
        {
            // Implementation for deleting a supplier
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
