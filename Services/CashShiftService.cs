using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class CashShiftService
    {
        private readonly IGenericRepository<CashShift> _cashShiftRepository;

        public CashShiftService(IGenericRepository<CashShift> cashShiftRepository)
        {
            _cashShiftRepository  = cashShiftRepository;
        }

        // Get All CashShifts with Pagination
        public async Task<IEnumerable<CashShift>> GetPagedCashShifts(int pageNumber, int pageSize)
        {
            return await _cashShiftRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a CashShift By Id
        public async Task<CashShift> GetCashShiftByIdAsync(int id)
        {
            return await _cashShiftRepository.GetByIdAsync(id);
        }

        public async Task CreateCashShiftAsync(CashShift cashShift)
        {
            await _cashShiftRepository.CreateAsync(cashShift);
        }

        //Update an Existing CashShift
        public async Task UpdateCashShiftAsync(CashShift cashShift)
        {
            var existingCashShift = await _cashShiftRepository.GetByIdAsync(cashShift.CashShiftId);
            if (existingCashShift == null)
            {
                throw new InvalidOperationException("Cash Shift Not Found.");
            }

            /*
                public DateTime ShiftDate { get; set; }
                public DateTime ShiftStart { get; set; }
                public DateTime? ShiftEnd { get; set; }
                public decimal OpeningBalance { get; set; }
                public decimal ClosingBalance { get; set; }
                public decimal TotalSales { get; set; }
                public decimal TotalRefunds { get; set; }
                public decimal CashIn { get; set; }
                public decimal CashOut { get; set; }
             */

            //Updating Data
            existingCashShift.ShiftDate = cashShift.ShiftDate;
            existingCashShift.ShiftStart = cashShift.ShiftStart;
            existingCashShift.ShiftEnd = cashShift.ShiftEnd;
            existingCashShift.OpeningBalance = cashShift.OpeningBalance;
            existingCashShift.ClosingBalance = cashShift.ClosingBalance;
            existingCashShift.TotalSales = cashShift.TotalSales;
            existingCashShift.TotalRefunds = cashShift.TotalRefunds;
            existingCashShift.CashIn = cashShift.CashIn;
            existingCashShift.CashOut = cashShift.CashOut;

            await _cashShiftRepository.UpdateAsync(existingCashShift);
        }

        //Delete a CashShift By Id
        public async Task DeleteCashShitAsync(int id)
        {
            await _cashShiftRepository.DeleteAsync(id);
        }
    }
}
