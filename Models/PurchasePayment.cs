using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class PurchasePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int PurchasePaymentId { get; set; }
        [Required]
        public int PurchaseId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; } = decimal.Zero;
        public string PaymentType { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual Purchase? Purchase { get; set; }
    }
}
