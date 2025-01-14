using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class ProductBatchDTO
    {
        public int ProductBatchId { get; set; }
        public int ProductId { get; set; }
        public string BatchNumber { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.UtcNow;
    }
}
