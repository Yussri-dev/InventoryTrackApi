using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services.Interfaces;

namespace InventoryTrackApi.Services
{
    public class LineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // Get all lines with pagination
        public async Task<IEnumerable<Line>> GetPagedLines(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Lines.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<Line>> GetLineByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _unitOfWork.Lines.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Get a line by ID
        public async Task<Line> GetLineByIdAsync(int id)
        {
            return await _unitOfWork.Lines.GetByIdAsync(id);
        }

        // Create a new line
        public async Task CreateLineAsync(Line line)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool exists = await _unitOfWork.Lines.ExistsAsync(p => p.Name == line.Name);

                if (exists)
                {
                    throw new InvalidOperationException("Line with the same Rate already exists.");
                }
                await _unitOfWork.Lines.CreateAsync(line);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        // Update an existing line
        public async Task UpdateLineAsync(Line line)
        {
            var existingLine = await _unitOfWork.Lines.GetByIdAsync(line.LineId);
            if (existingLine == null)
            {
                throw new InvalidOperationException("Line Not Found");
            }
            existingLine.Name = line.Name;

            await _unitOfWork.Lines.UpdateAsync(existingLine);
        }

        // Delete a line by ID
        public async Task DeleteLineAsync(int id)
        {
            await _unitOfWork.Lines.DeleteAsync(id);
        }
    }
}
