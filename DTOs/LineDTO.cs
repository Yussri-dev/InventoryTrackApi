using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class LineDTO
    {
        public int LineId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
