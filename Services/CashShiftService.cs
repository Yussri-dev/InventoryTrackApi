using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;
using System.Linq.Expressions;

namespace InventoryTrackApi.Services
{
    public class CashShiftService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CashShiftService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get All CashShifts with Pagination
        public async Task<IEnumerable<CashShift>> GetPagedCashShifts(int pageNumber, int pageSize)
        {
            return await _unitOfWork.CashShifts.GetAllAsync(pageNumber, pageSize);
        }

        //Get a CashShift By Id
        public async Task<CashShift> GetCashShiftByIdAsync(int id)
        {
            return await _unitOfWork.CashShifts.GetByIdAsync(id);
        }

        public async Task<CashShift> GetCashShiftByIdAndDateAsync(string userid)
        {
            Expression<Func<CashShift, bool>> cashShiftFilter =
                cashShift =>
                cashShift.ShiftDate.Date == DateTime.Now.Date &&
                cashShift.UserId == userid;
           
            return await _unitOfWork.CashShifts.GetByDataConditionAsync(cashShiftFilter);
        }
        public async Task CreateCashShiftAsync(CashShift cashShift)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.CashShifts.CreateAsync(cashShift);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //Update an Existing CashShift
        public async Task UpdateCashShiftAsync(CashShift cashShift)
        {
            var existingCashShift = await _unitOfWork.CashShifts.GetByIdAsync(cashShift.CashShiftId);
            if (existingCashShift == null)
            {
                throw new InvalidOperationException("Cash Shift Not Found.");
            }

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
            existingCashShift.SaasClientId = cashShift.SaasClientId;

            await _unitOfWork.CashShifts.UpdateAsync(existingCashShift);
        }

        //Delete a CashShift By Id
        public async Task DeleteCashShitAsync(int id)
        {
            await _unitOfWork.CashShifts.DeleteAsync(id);
        }

        public async Task<CashShiftCloseResultDto> CloseCashShiftAsync(int shiftId, decimal cash)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var shift = await _unitOfWork.CashShifts.GetByIdAsync(shiftId);
                if (shift == null || shift.ShiftEnd != null)
                    throw new InvalidOperationException("Cash shift not found or already closed.");

                shift.ShiftEnd = DateTime.Now;
                //var actualCash = cash;
                var expected = shift.DrawerBalance;

                shift.ClosingBalance = cash;
                await _unitOfWork.CashShifts.UpdateAsync(shift);
                await _unitOfWork.CommitAsync();

                return new CashShiftCloseResultDto
                {
                    Actual = cash,
                    Expected = expected
                };
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //public async Task<CashShiftCloseResultDto> CloseCashShiftAsync(int shiftId, CashCountDto cashCountDto)
        //{
        //    await _unitOfWork.BeginTransactionAsync();
        //    try
        //    {
        //        var shift = await _unitOfWork.CashShifts.GetByIdAsync(shiftId);
        //        if (shift == null || shift.ShiftEnd != null)
        //            throw new InvalidOperationException("Cash shift not found or already closed.");

        //        shift.ShiftEnd = DateTime.UtcNow;
        //        var actualCash = CalculatePhysicalCash(cashCountDto).TotalGeneral;
        //        var expected = shift.DrawerBalance;

        //        shift.ClosingBalance = actualCash;
        //        await _unitOfWork.CashShifts.UpdateAsync(shift);
        //        await _unitOfWork.CommitAsync();

        //        return new CashShiftCloseResultDto
        //        {
        //            Actual = actualCash,
        //            Expected = expected
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        await _unitOfWork.RollbackAsync();
        //        throw;
        //    }
        //}


        private CashCountResultDto CalculatePhysicalCash(CashCountDto count)
        {
            decimal coins = count.Cents1 * 0.01m
                          + count.Cents2 * 0.02m
                          + count.Cents5 * 0.05m
                          + count.Cents10 * 0.10m
                          + count.Cents20 * 0.20m
                          + count.Cents50 * 0.50m
                          + count.Euro1 * 1.00m
                          + count.Euro2 * 2.00m;

            decimal bills = count.Euro5 * 5.00m
                          + count.Euro10 * 10.00m
                          + count.Euro20 * 20.00m
                          + count.Euro50 * 50.00m
                          + count.Euro100 * 100.00m
                          + count.Euro200 * 200.00m
                          + count.Euro500 * 500.00m;

            return new CashCountResultDto
            {
                TotalCoins = coins,
                TotalBills = bills
            };
        }

    }
}
