using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class User
    {
        public string Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
        public bool IsActive { get; set; }
        
        [Required]
        public int SaasClientId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<CashShift> CashShifts { get; set; }
        public virtual ICollection<CashRegister> CashRegisters { get; set; }
    }
}
