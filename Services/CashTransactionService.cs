using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class CashTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CashTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CashTransaction>> GetPagedCashTransactionAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.CashTransactions.GetAllAsync(pageNumber, pageSize);
        }

        // Get CashTransaction by Id
        public async Task<CashTransaction> GetCashTransactionByIdAsync(int id)
        {
            return await _unitOfWork.CashTransactions.GetByIdAsync(id);
        }

        //Create a new Cash Transaction
        public async Task CreateCashTransactionAsync(CashTransaction cashTransaction)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.CashTransactions.CreateAsync(cashTransaction);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        //Update an Existing Cash Transaction
        public async Task UpdateCashTransactionAsync(CashTransaction cashTransaction)
        {
            var existingCashTransaction = await _unitOfWork.CashTransactions.GetByIdAsync(cashTransaction.CashTransactionId);

            if (existingCashTransaction == null)
            {
                throw new InvalidOperationException("CashTransaction ");
            }

            existingCashTransaction.TransactionType = cashTransaction.TransactionType;
            existingCashTransaction.Amount = cashTransaction.Amount;
            existingCashTransaction.TransactionTime = cashTransaction.TransactionTime;
            existingCashTransaction.Description = cashTransaction.Description;
            existingCashTransaction.SaasClientId = cashTransaction.SaasClientId;
            //Call the repository to update the exissting
            await _unitOfWork.CashTransactions.UpdateAsync(existingCashTransaction);
        }

        //Delete a Cash Transaction
        public async Task DeleteCashTransactionAsync(int id)
        {
            await _unitOfWork.CashTransactions.DeleteAsync(id);
        }
    }
}
