using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class ReturnItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnItemId { get; set; }
        [Required]
        public int ReturnId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; } = 0m;
        public decimal Price { get; set; } = 0m;
        public decimal ProfitMarge { get; set; } = 0m;
        public decimal PurchasePrice { get; set; } = 0m;
        public decimal Discount { get; set; } = decimal.Zero;
        public decimal TaxAmount { get; set; } = decimal.Zero;
        public decimal Total { get; set; } = decimal.Zero;

        public decimal RefundAmount { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        [JsonIgnore]
        public virtual Return? Return { get; set; }

        [JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
