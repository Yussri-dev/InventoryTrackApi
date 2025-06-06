using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        //public string NameComplete => FirstName + " " + LastName;
        public string NameComplete => $"{FirstName} {LastName}";
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "Number cannot exceed 15 characters.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Number must contain only numeric values.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<CashShift> CashShifts { get; set; }
        public virtual ICollection<CashRegister> CashRegisters { get; set; }

    }
}
