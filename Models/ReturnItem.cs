using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class ReturnItem
    {
        /*
            ReturnItemId INT PRIMARY KEY IDENTITY(1,1),   -- Return item identifier
            ReturnId INT FOREIGN KEY REFERENCES Returns(ReturnId),  -- Reference to the parent return
            ProductId INT FOREIGN KEY REFERENCES Products(ProductId),  -- Product being returned
            QuantityReturned INT NOT NULL,                  -- Quantity of this product returned
            RefundAmount DECIMAL(18,2),                     -- Refund amount for this item
            CreatedAt DATETIME DEFAULT GETDATE(),           -- Record creation date
            UpdatedAt DATETIME DEFAULT GETDATE()            -- Record update date
         */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReturnItemId { get; set; }
        [Required]
        public int ReturnId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; } = 0m;
        public decimal RefundAmount { get; set; } = 0m;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public virtual Return? Return { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
