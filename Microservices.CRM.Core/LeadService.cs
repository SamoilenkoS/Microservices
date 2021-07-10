using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.CRM.Core
{
    public class LeadService : ILeadService
    {
        public async Task<Guid> CreateLeadAsync(Lead lead)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateLeadAsync(Lead lead)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveLeadAsync(Guid leadId)
        {
            throw new NotImplementedException();
        }

        public async Task<Lead> GetLeadAsync(Guid leadId)
        {
            throw new NotImplementedException();
        }
    }
}
