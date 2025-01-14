using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventoryTrackApi.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Location name cannot exceed 50 characters.")]
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

        public bool IsActivated { get; set; } = true;

        public virtual ICollection<InventoryMouvement> InventoryMouvements { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<CashRegister> CashRegisters { get; set; }
    }
}
