using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime SaleDate { get; set; } = DateTime.Now;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        //public string UserId { get; set; }
        public string UserId { get; set; }

        [Required]
        public decimal TvaAmount { get; set; } = 0m;
        [Required]
        public decimal TotalAmount { get; set; } = 0m;
        [Required]
        public decimal AmountPaid { get; set; } = 0m;

        public decimal OutstandingBalance => TotalAmount - AmountPaid;
        public decimal DiscountPercentage { get; set; } = decimal.Zero;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }
        //public virtual User? User { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        [JsonIgnore]
        public virtual ICollection<SaleItem>? SaleItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<SalePayment>? SalePayments { get; set; }

        [JsonIgnore]
        public virtual ICollection<Return>? Returns { get; set; }

    }
}
