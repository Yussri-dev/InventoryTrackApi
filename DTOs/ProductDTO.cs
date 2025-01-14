using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public int ProductUnitId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal MinStock { get; set; }
        public decimal MaxStock { get; set; }
        public string PackUnitType { get; set; } = string.Empty;
        public decimal QuantityStock { get; set; }
        public decimal QuantityPack { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; } = 0;
        public decimal SalePrice1 { get; set; } = 0;
        public decimal SalePrice2 { get; set; } = 0;
        public decimal SalePrice3 { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime DateModified { get; set; } = DateTime.Now;
        public bool IsActivate { get; set; } = true;
        public decimal DiscountPercentage { get; set; } = decimal.Zero;
        public bool IsSecondItemDiscountEligible { get; set; } // For "second product" discounts
        public bool IsBuyThreeForFiveEligible { get; set; } // For "Buy 3 for 5" offer

        public int ShelfId { get; set; }
        public string ShelfName { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public int UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;

        public int TaxId { get; set; }
        public decimal TaxRate { get; set; }

        public int LineId { get; set; }
        public string LineName { get; set; } = string.Empty;
    }
}
