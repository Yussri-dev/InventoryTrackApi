using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class SalePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalePaymentId { get; set; }
        [Required]
        public int SaleId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; } = decimal.Zero;
        // "CASH", "CREDIT", "PARTIAL_PAYMENT"
        public string PaymentType { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual Sale? Sale { get; set; }
    }
}
