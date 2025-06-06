using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class CashRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CashRegisterId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [Required]
        public int LocationId { get; set; }

        //[Required]
        //public string UserId { get; set; }

        [Required]
        public string UserId { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual Location? Location { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        public ICollection<CashShift> CashShifts { get; set; }
    }

}
