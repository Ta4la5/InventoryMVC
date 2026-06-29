using System.ComponentModel.DataAnnotations;

namespace InventoryMVC.DTOs
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; }
    }
}
