using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventoryTrackApi.DTOs
{
    public class PurchaseDTO
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public int SupplierId { get; set; }
        public int EmployeeId { get; set; }
        public decimal TvaAmount { get; set; } = 0m;
        public decimal TotalAmount { get; set; } = 0m;
        public decimal AmountPaid { get; set; } = 0m;
        public decimal OutstandingBalance => TotalAmount - AmountPaid;
    }
}
