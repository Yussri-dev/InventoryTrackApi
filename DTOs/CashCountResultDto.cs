namespace InventoryTrackApi.DTOs
{
    public class CashCountResultDto
    {
        public decimal TotalCoins { get; set; }
        public decimal TotalBills { get; set; }

        public decimal TotalGeneral => TotalCoins + TotalBills;
    }

}
