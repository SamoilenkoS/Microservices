using System;
using System.Threading.Tasks;

namespace Microservices.CRM.Core
{
    public interface ILeadService
    {
        Task<Guid> CreateLeadAsync(Lead lead);
        Task<bool> UpdateLeadAsync(Lead lead);
        Task<bool> RemoveLeadAsync(Guid leadId);
        Task<Lead> GetLeadAsync(Guid leadId);
    }
}
