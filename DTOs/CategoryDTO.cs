using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
