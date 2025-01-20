using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace InventoryTrackApi.Models
{
    [Index(nameof(Barcode), IsUnique = true)]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public decimal MinStock { get; set; } = 5;
        public decimal MaxStock { get; set; } = 100;

        [Required]
        public string PackUnitType { get; set; } = string.Empty;

        public decimal QuantityStock { get; set; } = 0;
        public decimal QuantityPack { get; set; } = 1;

        [MaxLength(14)]
        public string Barcode { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; } = 0;
        public decimal SalePrice1 { get; set; } = 0;
        public decimal SalePrice2 { get; set; } = 0;
        public decimal SalePrice3 { get; set; } = 0;
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = string.Empty;

        [DefaultValue("DateTime.Now")]
        public DateTime DateModified { get; set; } = DateTime.Now;
        public bool IsActivate { get; set; } = true;
        public decimal DiscountPercentage { get; set; } = decimal.Zero;
        public bool IsSecondItemDiscountEligible { get; set; } = false;
        public bool IsBuyThreeForFiveEligible { get; set; } = false;
        // Foreign key properties
        [Required]
        public int ShelfId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int TaxId { get; set; }
        [Required]
        public int LineId { get; set; }
        // Navigation properties
        [JsonIgnore]
        public virtual Shelf? Shelf { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }
        [JsonIgnore]
        public virtual Unit? Unit { get; set; }
        [JsonIgnore]
        public virtual Tax? Tax { get; set; }
        [JsonIgnore]
        public virtual Line? Line { get; set; }

        public virtual ICollection<ProductBatch> ProductBatches { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<InventoryMouvement> InventoryMouvements { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
        public virtual ICollection<ReturnItem> ReturnItems { get; set; }

    }



}
