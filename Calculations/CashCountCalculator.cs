using InventoryTrackApi.DTOs;

namespace InventoryTrackApi.Calculations
{
    public class CashCountCalculator
    {
        public CashCountResultDto CalculateTotals(CashCountDto dto)
        {
            var totalCoins =
                dto.Cents1 * 0.01m +
                dto.Cents2 * 0.02m +
                dto.Cents5 * 0.05m +
                dto.Cents10 * 0.10m +
                dto.Cents20 * 0.20m +
                dto.Cents50 * 0.50m +
                dto.Euro1 * 1.00m +
                dto.Euro2 * 2.00m;

            var totalBills =
                dto.Euro5 * 5.00m +
                dto.Euro10 * 10.00m +
                dto.Euro20 * 20.00m +
                dto.Euro50 * 50.00m +
                dto.Euro100 * 100.00m +
                dto.Euro200 * 200.00m +
                dto.Euro500 * 500.00m;

            return new CashCountResultDto
            {
                TotalCoins = totalCoins,
                TotalBills = totalBills,
            };
        }
    }

}
