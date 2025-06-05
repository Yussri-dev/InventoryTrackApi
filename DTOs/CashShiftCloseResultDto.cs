namespace InventoryTrackApi.DTOs
{
    public class CashShiftCloseResultDto
    {
        public decimal Cash { get; set; }
        public decimal Expected { get; set; }
        public decimal Actual { get; set; }
        public decimal Difference => Actual - Expected;
    }

}
