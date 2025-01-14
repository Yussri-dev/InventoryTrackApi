using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.Models
{
    public class Line
    {
        [Key]
        public int LineId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Unit name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// List of Products Related to Line
        /// </summary>
        public virtual List<Product> Products { get; set; }
    }
}
