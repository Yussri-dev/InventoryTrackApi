namespace InventoryTrackApi.DTOs
{
    public class PurchaseFlatDTO
    {
        #region Purchase

        // Purchase info
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int EmployeeId { get; set; }
        public decimal TvaAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }

        #endregion

        #region PurchaseItems 
        // Item info
        public int PurchaseItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LineTotal { get; set; }
        #endregion

        #region Product
        // Product info
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice1 { get; set; }
        public decimal SalePrice2 { get; set; }
        public decimal SalePrice3 { get; set; }
        public string Barcode { get; set; }
        public decimal QuantityStock { get; set; }
        public decimal QuantityPack { get; set; }
        #endregion
    }

}
