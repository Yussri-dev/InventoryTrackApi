using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Return
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnId { get; set; }

        public int SaleId { get; set; }

        public DateTime ReturnDate { get; set; } = DateTime.Now;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        //public string UserId { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal RefundAmount { get; set; } = 0m;
        [Required]
        public string ReturnMethod { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual Customer? Customer { get; set; }

        [JsonIgnore]
        public virtual Sale? Sale { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        // Nullable collections
        [JsonIgnore]
        public virtual ICollection<ReturnItem>? ReturnItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<ReturnPayment>? ReturnPayments { get; set; }

    }
}
