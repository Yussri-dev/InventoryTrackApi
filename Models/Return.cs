using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Return
    {
        /*
            //ReturnId INT PRIMARY KEY IDENTITY(1,1),      -- Return identifier
            //SaleId INT FOREIGN KEY REFERENCES Sales(SaleId),  -- Reference to the original sale
            //ReturnDate DATETIME DEFAULT GETDATE(),          -- Date of the return
            //Reason NVARCHAR(255),                           -- Reason for the return
            //Status NVARCHAR(50) DEFAULT 'Pending',          -- Status of the return (e.g., 'Pending', 'Approved', etc.)
            //RefundAmount DECIMAL(18,2),                     -- Total refund amount for this return
            ReturnMethod NVARCHAR(50),                      -- Return method (e.g., refund, exchange, etc.)
            CreatedAt DATETIME DEFAULT GETDATE(),           -- Record creation date
            UpdatedAt DATETIME DEFAULT GETDATE()            -- Record update date
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnId { get; set; }
        public int SaleId { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime returnDate { get; set; } = DateTime.Now;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal RefundAmount { get; set; } = 0m;
        [Required]
        public string ReturnMethod { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }
        [JsonIgnore]
        public virtual Sale? Sale { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReturnItem> returnItems { get; set; }
        public virtual ICollection<ReturnPayment> ReturnPayments { get; set; }
    }
}
