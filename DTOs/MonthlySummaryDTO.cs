namespace InventoryTrackApi.DTOs
{
    public class MonthlySummaryDTO
    {
        public string Month { get; set; }
        public int Year { get; set; }
        public string MonthYear { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal PurchasesAmount { get; set; }
        public int SalesCount { get; set; }
        public int PurchasesCount { get; set; }
    }
}
