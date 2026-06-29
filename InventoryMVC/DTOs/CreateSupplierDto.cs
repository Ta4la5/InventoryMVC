using System.ComponentModel.DataAnnotations;

namespace InventoryMVC.DTOs
{
    public class CreateSupplierDto
    { 
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
