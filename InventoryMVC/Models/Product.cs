namespace InventoryMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
    }
}
