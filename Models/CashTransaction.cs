﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class CashTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CashTransactionId { get; set; }
        [Required]
        public int CashShiftId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; } = decimal.Zero;
        public DateTime TransactionTime { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }
        [JsonIgnore]
        public virtual CashShift? CashShift { get; set; }
    }
}
