using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microservices.CRM.Core;

namespace Microservices.CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IBusControl _busControl;

        public TransactionController(IBusControl busControl)
        {
            _busControl = busControl;
        }

        [HttpPost]
        public async Task DepositMoneyAsync([FromBody] MoneyTransaction moneyTransaction)
        {
            moneyTransaction.SenderAccountId = Guid.NewGuid();
            moneyTransaction.Timestamp = DateTime.Now;
            await _busControl.Publish(moneyTransaction);
        }
    }
}
