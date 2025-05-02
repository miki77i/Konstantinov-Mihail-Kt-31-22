using KonstantinovMihailKt_31_22.Interfaces.CafedraInterfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonstantinovMihailKt_31_22.Filters.CafedraFilters;

namespace KonstantinovMihailKt_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NagruzkaController : ControllerBase
    {
        private readonly ILogger<NagruzkaController> _logger;
        private readonly INagruzkaService _nagruzkaService;

        public NagruzkaController(ILogger<NagruzkaController> logger, INagruzkaService nagruzkaService)
        {
            _logger = logger;
            _nagruzkaService = nagruzkaService;
        }

        [HttpPost("GetNagruzkaByFilter")]

        public async Task<IActionResult> GetNagruzkaByFiltersAsync([FromBody] NagruzkaFilter filter, CancellationToken cancellationToken = default)
        {
            var nagruzka = await _nagruzkaService.GetNagruzkasByFiltersAsync(filter, cancellationToken);
            return Ok(nagruzka);
        }
    }
}
