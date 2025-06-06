using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class CashShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CashShiftId { get; set; }

        public DateTime ShiftDate { get; set; }
        public DateTime ShiftStart { get; set; } = DateTime.UtcNow;
        public DateTime? ShiftEnd { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalRefunds { get; set; }
        public decimal CashIn { get; set; }
        public decimal CashOut { get; set; }

        public bool IsActive => ShiftEnd == null;

        //knowing how much cash should be physically in the drawer at any point.
        [NotMapped]
        public decimal DrawerBalance => OpeningBalance + CashIn - CashOut;


        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }


        [Required]
        public int CashRegisterId { get; set; }
        [Required]
        //public string UserId { get; set; }
        public string UserId { get; set; }

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }


        [JsonIgnore]
        public virtual CashRegister CashRegister { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        public ICollection<CashTransaction> CashTransactions { get; set; }
    }
}
