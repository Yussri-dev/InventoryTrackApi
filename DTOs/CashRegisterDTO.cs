using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class CashRegisterDTO
    {
        public int CashRegisterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
