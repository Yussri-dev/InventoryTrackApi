using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventoryTrackApi.DTOs
{
    public class ReturnDTO
    {
        public int ReturnId { get; set; }
        public int SaleId { get; set; }
        public DateTime returnDate { get; set; }
        public int CustomerId { get; set; }
        public string UserId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public decimal RefundAmount { get; set; }
        public string ReturnMethod { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CustomerName { get; set; }
        public int SaasClientId { get; set; }

    }
}
