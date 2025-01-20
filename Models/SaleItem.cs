using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class SaleItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleItemId { get; set; }
        [Required]
        public int SaleId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; } = 0m;
        public decimal Price { get; set; } = 0m;
        public decimal Discount { get; set; } = decimal.Zero;
        public decimal TaxAmount { get; set; } = decimal.Zero;
        public decimal Total { get; set; } = decimal.Zero;

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public virtual Sale? Sale { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        //public virtual ICollection<Product> Products { get; set; }

    }
}
