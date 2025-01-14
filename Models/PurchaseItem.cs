using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class PurchaseItem
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PurchaseItemId { get; set; }
        //[Required]
        //public int PurchaseId { get; set; }
        //[Required]
        //public int ProductId { get; set; }
        //public decimal Quantity { get; set; } = 0m;
        //public decimal Price { get; set; } = 0m;
        //public decimal Discount { get; set; } = decimal.Zero;
        //public decimal TaxAmount { get; set; } = decimal.Zero;
        //public decimal Total { get; set; } = decimal.Zero;

        //[JsonIgnore]
        //public virtual Purchase? Purchase { get; set; }
        //[JsonIgnore]
        //public virtual Product? Product { get; set; }
        //public virtual ICollection<Product> Products { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseItemId { get; set; }
        [Required]
        public int PurchaseId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; } = 0m;
        public decimal Price { get; set; } = 0m;
        public decimal Discount { get; set; } = decimal.Zero;
        public decimal TaxAmount { get; set; } = decimal.Zero;
        public decimal Total { get; set; } = decimal.Zero;

        [JsonIgnore]
        public virtual Purchase? Purchase { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
