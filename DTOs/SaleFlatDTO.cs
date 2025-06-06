﻿namespace InventoryTrackApi.DTOs
{
    public class SaleFlatDTO
    {
        #region Sale

        // Sale info
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public string UserId { get; set; }
        public decimal TvaAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal OutstandingBalance => TotalAmount - AmountPaid;
        public decimal DiscountPercentage { get; set; }
        public string CustomerName { get; set; }
        public int SaasClientId { get; set; }

        #endregion

        #region SaleItems 
        // Item info
        public int SaleItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ProfitMarge { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        #endregion

        #region Product
        // Product info
        public string ProductName { get; set; }
        public decimal SalePrice1 { get; set; }
        public decimal SalePrice2 { get; set; }
        public decimal SalePrice3 { get; set; }
        public string Barcode { get; set; }
        public decimal QuantityStock { get; set; }
        public decimal QuantityPack { get; set; }
        #endregion
    }

}
