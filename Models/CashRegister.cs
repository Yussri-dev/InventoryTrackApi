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
        [Required]
        public int EmployeeId { get; set; }
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual Location? Location { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }

        public ICollection<CashShift> CashShifts { get; set; }
        public ICollection<CashRegister> CashRegisters { get; set; }
    }
}
