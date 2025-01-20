using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTrackApi.Models
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxId { get; set; }

        [Required]
        public decimal TaxRate { get; set; } = decimal.Zero;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// List of products related to the tax rate.
        /// </summary>
        public virtual List<Product> Products { get; set; }
        public virtual List<SaleItem> SaleItems { get; set; }
    }
}
