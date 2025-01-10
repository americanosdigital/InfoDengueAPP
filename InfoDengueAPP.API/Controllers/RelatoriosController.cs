using InfoDengueAPP.Domain.Entities;
using InfoDengueAPP.SERVICES.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoDengueAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relatorios = await _relatorioService.GetAllAsync();
            return Ok(relatorios);
        }

        [HttpGet("rj-sp")]
        public async Task<IActionResult> GetAllEpidemiologicalDataForRJAndSP()
        {
            var relatorios = await _relatorioService.GetAllEpidemiologicalDataForRJAndSPAsync();
            return Ok(relatorios);
        }

        [HttpGet("by-codigo-ibge/{codigoIbge}")]
        public async Task<IActionResult> GetByCodigoIbge(string codigoIbge)
        {
            var relatorios = await _relatorioService.GetByIbgeCodeAsync(codigoIbge);
            return Ok(relatorios);
        }

        [HttpGet("by-arbovirose/{arbovirose}")]
        public async Task<IActionResult> GetByArbovirose(string arbovirose)
        {
            var relatorios = await _relatorioService.GetByArboviroseAsync(arbovirose);
            return Ok(relatorios);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Relatorio relatorio)
        {
            await _relatorioService.AddAsync(relatorio);
            return Ok();
        }
    }

}
