using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Finances.Business.Domain.Dtos;
using Finances.Business.Application.Interfaces;

namespace Finances.API.Controllers
{
    [ApiController]
    [Route("finances")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceService _service;

        public FinanceController(IFinanceService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] FinanceRequest request)
        {
            return await _service.CreateFinanceAsync(request);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            return await _service.GetFinanceAsync();
        }
    }
}
