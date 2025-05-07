using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class ProductBatch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductBatchId { get; set; }
       
        [Required]
        public string BatchNumber { get; set; } = string.Empty;
        public decimal Quantity { get; set; } = 0;
        public DateTime? ExpirationDate { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }

        public decimal PurchasePrice { get; set; } = 0; 

        public decimal SalePrice { get; set; } = 0;
    }
}
