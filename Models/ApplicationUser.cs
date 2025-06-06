using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoginTime { get; set; }

        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; }
        [JsonIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }
        [JsonIgnore]
        public virtual ICollection<Return> Returns { get; set; }
        [JsonIgnore]
        public virtual ICollection<CashRegister> CashRegisters { get; set; }
        [JsonIgnore]
        public virtual ICollection<CashShift> CashRegisterShifts { get; set; }
    }

}
