using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class UnitDTO
    {
        public int UnitId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
