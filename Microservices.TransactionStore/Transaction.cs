using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.TransactionStore
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Guid From { get; set; }
        public Guid To { get; set; }
        public DateTime Timestamp { get; set; }

    }
}