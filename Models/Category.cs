using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTrackApi.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// List of Products related to Category
        /// </summary>
        public virtual List<Product> Products { get; set; }

    }
}
