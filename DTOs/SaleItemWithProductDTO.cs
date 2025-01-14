namespace InventoryTrackApi.DTOs
{
    public class SaleItemWithProductDTO
    {
        //SaleItem Field
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }

        // Product fields
        public string ProductName { get; set; }
        public decimal MinStock { get; set; }
        public decimal MaxStock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool IsSecondItemDiscountEligible { get; set; }
        public bool IsBuyThreeForFiveEligible { get; set; }
    }
}
