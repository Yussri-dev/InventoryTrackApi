using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class CashTransactionService
    {

        private readonly IGenericRepository<CashTransaction> _cashTransactionRepository;

        //Constructor to inject the repository
        public CashTransactionService(IGenericRepository<CashTransaction> cashTransactionRepository)
        {
            _cashTransactionRepository = cashTransactionRepository;
        }

        // Get All CashTransaction with Pagination

        public async Task<IEnumerable<CashTransaction>> GetPagedCashTransactionAsync(int pageNumber, int pageSize)
        {
            return await _cashTransactionRepository.GetAllAsync(pageNumber, pageSize);
        }

        // Get CashTransaction by Id
        public async Task<CashTransaction> GetCashTransactionByIdAsync(int id)
        {
            return await _cashTransactionRepository.GetByIdAsync(id);
        }

        //Create a new Cash Transaction
        public async Task CreateCashTransactionAsync(CashTransaction cashTransaction)
        {
            await _cashTransactionRepository.CreateAsync(cashTransaction);
        }

        //Update an Existing Cash Transaction
        public async Task UpdateCashTransactionAsync(CashTransaction cashTransaction)
        {
            var existingCashTransaction = await _cashTransactionRepository.GetByIdAsync(cashTransaction.CashTransactionId);

            if (existingCashTransaction == null)
            {
                throw new InvalidOperationException("CashTransaction ");
            }

            existingCashTransaction.TransactionType = cashTransaction.TransactionType;
            existingCashTransaction.Amount = cashTransaction.Amount;
            existingCashTransaction.TransactionTime = cashTransaction.TransactionTime;
            existingCashTransaction.Description = cashTransaction.Description;

            //Call the repository to update the exissting
            await _cashTransactionRepository.UpdateAsync(existingCashTransaction);
        }

        //Delete a Cash Transaction
        public async Task DeleteCashTransactionAsync(int id)
        {
            await _cashTransactionRepository.DeleteAsync(id);
        }
    }
}
