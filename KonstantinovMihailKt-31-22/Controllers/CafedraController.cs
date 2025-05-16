using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using KonstantinovMihailKt_31_22.Filters;
using KonstantinovMihailKt_31_22.Interfaces;
using KonstantinovMihailKt_31_22.Interfaces.CafedraInterfase;
using KonstantinovMihailKt_31_22.Filters.CafedraFilters;

namespace KonstantinovMihailKt_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CafedraController : ControllerBase
    {
        private readonly ILogger<CafedraController> _logger;
        private readonly ICafedraService _cafedraService;

        public CafedraController(ILogger<CafedraController> logger, ICafedraService cafedraService)
        {
            _logger = logger;
            _cafedraService = cafedraService;
        }

        [HttpPost("GetCafedraByFilter")]
        public async Task<IActionResult> GetCafedrasByFilterAsync([FromBody] CafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var cafedra = await _cafedraService.GetCafedrasByFilterAsync(filter, cancellationToken);
            return Ok(cafedra);
        }

    }
}
