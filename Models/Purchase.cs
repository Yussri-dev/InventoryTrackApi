using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        
        [Required]
        public decimal TvaAmount { get; set; } = 0m;
        [Required]
        public decimal TotalAmount { get; set; } = 0m;
        [Required]
        public decimal AmountPaid { get; set; } = 0m;

        public decimal OutstandingBalance => TotalAmount - AmountPaid;

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public int SupplierId { get; set; }
        [Required]
        //public string UserId { get; set; }
        public string UserId { get; set; }


        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }
        [JsonIgnore]
        public virtual Supplier? Supplier { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<PurchasePayment> PurchasePayments { get; set; }


    }
}
