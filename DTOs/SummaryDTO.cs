namespace InventoryTrackApi.DTOs
{
    public class SummaryDTO
    {
        public string Period { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public int TransactionCount { get; set; }
    }
}
