using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Supplier name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(15, ErrorMessage = "Number cannot exceed 15 characters.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Number must contain only numeric values.")]
        public string PhoneNumber1 { get; set; } = string.Empty;

        [Required]
        [MaxLength(15, ErrorMessage = "Number cannot exceed 15 characters.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Number must contain only numeric values.")]
        public string PhoneNumber2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        public string Adresse { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Land { get; set; } = string.Empty;

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = string.Empty;

        [DefaultValue("DateTime.Now")]
        public DateTime DateModified { get; set; } = DateTime.Now;

        public bool IsActivate { get; set; } = true;
        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        [JsonIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
