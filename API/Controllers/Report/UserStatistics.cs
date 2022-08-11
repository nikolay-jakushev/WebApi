using System;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Report
{
    [ApiController]
    [Route("/report/user_statistics")]
    public class UserStatistics : ControllerBase
    {
        private readonly IServiceRepository _context;

        public UserStatistics(IServiceRepository context)
        {
            this._context = context;
        }

        [HttpPost("{id}, {from}, {to}")]
        public async Task<ActionResult<Guid>> PostUserStatics(Guid id, int from, int to)
        {
            var result = await _context.SaveUser(id, from, to);
            return result;
        }

    }
}