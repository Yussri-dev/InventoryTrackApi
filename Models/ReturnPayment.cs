using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class ReturnPayment
    {
        /*
            ReturnPaymentId INT PRIMARY KEY IDENTITY(1,1),  -- Unique identifier for the return payment
            ReturnId INT FOREIGN KEY REFERENCES Returns(ReturnId),  -- Reference to the return
            PaymentMethod NVARCHAR(50),                       -- Method of payment (e.g., Credit Card, Bank Transfer, Cash)
            PaymentAmount DECIMAL(18,2),                      -- Total amount refunded
            PaymentDate DATETIME DEFAULT GETDATE(),           -- Date of refund payment
            PaymentStatus NVARCHAR(50) DEFAULT 'Pending',     -- Payment status (e.g., 'Pending', 'Completed', 'Failed')
            TransactionId NVARCHAR(255),                      -- External payment gateway transaction ID (if applicable)
            CreatedAt DATETIME DEFAULT GETDATE(),             -- Record creation date
            UpdatedAt DATETIME DEFAULT GETDATE()              -- Record update date
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnPaymentId { get; set; }
        [Required]
        public int ReturnId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; } = decimal.Zero;
        public string PaymentType { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public virtual Return? Return { get; set; }
    }
}
