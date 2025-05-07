using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class CashRegisterService
    {
        private readonly IGenericRepository<CashRegister> _cashRegisterRepository;
        public CashRegisterService(IGenericRepository<CashRegister> cashRegisterRepository)
        {
            _cashRegisterRepository = cashRegisterRepository;
        }

        //Get All CashRegister with Pagination
        public async Task<IEnumerable<CashRegister>> GetPagedCashRegistersAsync(int pageNumber, int pageSize)
        {
            return await _cashRegisterRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Cash Register by Id
        public async Task<CashRegister> GetCashRegisterByIdAsync(int id)
        {
            return await _cashRegisterRepository.GetByIdAsync(id);
        }


        //Create new CashRegister
        public async Task CreateCashRegisterAsync(CashRegister cashRegister)
        {
            bool exists = await _cashRegisterRepository.ExistsAsync(p => p.Name == cashRegister.Name);

            if (exists)
            {
                throw new InvalidOperationException("Cash Register with the same name already exists.");
            }

            await _cashRegisterRepository.CreateAsync(cashRegister);
        }

        //Update an existing CashRegister
        public async Task UpdateCashRegisterAsync(CashRegister cashRegister)
        {
            var exisitingCashRegister = await _cashRegisterRepository.GetByIdAsync(cashRegister.CashRegisterId);
            
            //Checking if CashRegister Exists
            if (exisitingCashRegister == null)
            {
                throw new InvalidOperationException("Cash Register not Found");
            }
            //Updating the properties to update the exisiting CashRegister in the DB
            exisitingCashRegister.Name = cashRegister.Name;
            exisitingCashRegister.IsActive = cashRegister.IsActive;

            await _cashRegisterRepository.UpdateAsync(exisitingCashRegister);
        }

        //Delete a cash register
        public async Task DeleteCashRegisterAsync(int id)
        {
            await _cashRegisterRepository.DeleteAsync(id);
        }
    }
}
