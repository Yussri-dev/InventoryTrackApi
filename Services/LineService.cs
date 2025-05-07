using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;

namespace InventoryTrackApi.Services
{
    public class LineService
    {
        private readonly IGenericRepository<Line> _lineRepository;

        // Constructor to inject the repository
        public LineService(IGenericRepository<Line> lineRepository)
        {
            _lineRepository = lineRepository;
        }
        // Get all lines with pagination
        public async Task<IEnumerable<Line>> GetPagedLines(int pageNumber, int pageSize)
        {
            return await _lineRepository.GetAllAsync(pageNumber, pageSize);
        }

        //Get a product by Name
        public async Task<IEnumerable<Line>> GetLineByNameAsync(string name)
        {
            //return await _productRepository.GetByNameAsync(p => EF.Functions.Like(p.Name, name));
            return await _lineRepository.GetByNameAsync(p => p.Name.Contains(name));
        }

        // Get a line by ID
        public async Task<Line> GetLineByIdAsync(int id)
        {
            return await _lineRepository.GetByIdAsync(id);
        }

        // Create a new line
        public async Task CreateLineAsync(Line line)
        {
            bool exists = await _lineRepository.ExistsAsync(p => p.Name == line.Name);

            if (exists)
            {
                throw new InvalidOperationException("Line with the same Rate already exists.");
            }
            await _lineRepository.CreateAsync(line);
        }

        // Update an existing line
        public async Task UpdateLineAsync(Line line)
        {
            var existingLine = await _lineRepository.GetByIdAsync(line.LineId);
            if (existingLine == null)
            {
                throw new InvalidOperationException("Line Not Found");
            }
            existingLine.Name = line.Name;

            await _lineRepository.UpdateAsync(existingLine);
        }

        // Delete a line by ID
        public async Task DeleteLineAsync(int id)
        {
            await _lineRepository.DeleteAsync(id);
        }
    }
}
