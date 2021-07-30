using System;
using System.Threading.Tasks;
using MassTransit;
using Microservices.CRM.Core;

namespace Microservices.TransactionStore
{
    public class MoneyTransactionConsumer : IConsumer<MoneyTransaction>
    {
        private readonly EFCoreContext _dbContext;
        public MoneyTransactionConsumer(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<MoneyTransaction> context)
        {
            var message = context.Message;
            await _dbContext.Transactions.AddAsync(new Transaction
            {
                Amount = message.Amount,
                Currency = message.Currency,
                Timestamp = message.Timestamp,
                From = message.SenderAccountId,
                To = Guid.NewGuid(),
                Id = Guid.NewGuid()
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
