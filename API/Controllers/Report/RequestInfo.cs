using System;
using System.Threading.Tasks;
using API.Services;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Report
{
    [ApiController]
    [Route("/report/info")]
    public class RequestInfo : ControllerBase
    {
        private readonly IServiceRepository _context;
    
        public RequestInfo(IServiceRepository context)
        {
            this._context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportInfo>> GetRequestInfo(Guid id)
        {
            var info = await _context.GetRequest(id);
            if(info == null) return NotFound();
            return info;
        }
    }
}