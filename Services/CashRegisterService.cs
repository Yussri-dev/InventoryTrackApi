using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class CashRegisterService
    {
        //private readonly IGenericRepository<CashRegister> _cashRegisterRepository;
        //public CashRegisterService(IGenericRepository<CashRegister> cashRegisterRepository)
        //{
        //    _cashRegisterRepository = cashRegisterRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public CashRegisterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get All CashRegister with Pagination
        public async Task<IEnumerable<CashRegister>> GetPagedCashRegistersAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.CashRegisters.GetAllAsync(pageNumber, pageSize);
        }

        //Get a Cash Register by Id
        public async Task<CashRegister> GetCashRegisterByIdAsync(int id)
        {
            return await _unitOfWork.CashRegisters.GetByIdAsync(id);
        }

        public async Task<CashRegister> GetCashRegisterByIdUserAsync(string id)
        {
            var cashUser = await _unitOfWork.CashRegisters.GetWhereAsync(
              cs =>
              cs.UserId == id);

            return cashUser.FirstOrDefault();
        }


        //Create new CashRegister
        public async Task CreateCashRegisterAsync(CashRegister cashRegister)
        {
            bool exists = await _unitOfWork.CashRegisters.ExistsAsync(p => p.Name == cashRegister.Name);

            if (exists)
            {
                throw new InvalidOperationException("Cash Register with the same name already exists.");
            }

            await _unitOfWork.CashRegisters.CreateAsync(cashRegister);
        }

        //Update an existing CashRegister
        public async Task UpdateCashRegisterAsync(CashRegister cashRegister)
        {
            var exisitingCashRegister = await _unitOfWork.CashRegisters.GetByIdAsync(cashRegister.CashRegisterId);

            //Checking if CashRegister Exists
            if (exisitingCashRegister == null)
            {
                throw new InvalidOperationException("Cash Register not Found");
            }
            //Updating the properties to update the exisiting CashRegister in the DB
            exisitingCashRegister.Name = cashRegister.Name;
            exisitingCashRegister.IsActive = cashRegister.IsActive;

            await _unitOfWork.CashRegisters.UpdateAsync(exisitingCashRegister);
        }

        //Delete a cash register
        public async Task DeleteCashRegisterAsync(int id)
        {
            await _unitOfWork.CashRegisters.DeleteAsync(id);
        }
    }
}
