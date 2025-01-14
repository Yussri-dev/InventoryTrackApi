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

        /// <summary>
        /// List of products related to the tax rate.
        /// </summary>
        public virtual List<Product> Products { get; set; }
        public virtual List<SaleItem> SaleItems { get; set; }
    }
}
