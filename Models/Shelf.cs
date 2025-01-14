using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTrackApi.Models
{
    public class Shelf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Shelf name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// List of products associated with this shelf.
        /// </summary>
        public virtual List<Product> Products { get; set; }
    }

}
