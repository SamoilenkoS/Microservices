using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microservices.CRM.Core;

namespace Microservices.TransactionStore
{
    public class MoneyTransactionConsumer : IConsumer<MoneyTransaction>
    {
        public async Task Consume(ConsumeContext<MoneyTransaction> context)
        {
            throw new NotImplementedException();
        }
    }
}
