using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microservices.CRM.Core;

namespace Microservices.CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost]
        public async Task<Guid> CreateLeadAsync([FromQuery] Lead lead)
        {
            return await _leadService.CreateLeadAsync(lead);
        }

        [HttpPost]
        public async Task<bool> UpdateLeadAsync([FromQuery]Lead lead)
        {
            return await _leadService.UpdateLeadAsync(lead);
        }

        [HttpDelete("{leadId}")]
        public async Task<bool> RemoveLeadAsync(Guid leadId)
        {
            return await _leadService.RemoveLeadAsync(leadId);
        }

        [HttpGet("leadId")]
        public async Task<Lead> GetLeadAsync(Guid leadId)
        {
            return await _leadService.GetLeadAsync(leadId);
        }
    }
}
