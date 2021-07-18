using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Microservices.CRM.Core
{
    public class MoneyTransaction
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        [JsonIgnore]
        public Guid SenderAccountId { get; set; }
        [JsonIgnore]
        public DateTime Timestamp { get; }
    }
}
