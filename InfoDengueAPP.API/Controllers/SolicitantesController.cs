using InfoDengueAPP.Domain.Entities;
using InfoDengueAPP.SERVICES.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoDengueAPP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitantesController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;

        public SolicitantesController(ISolicitanteService solicitanteService)
        {
            _solicitanteService = solicitanteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var solicitantes = await _solicitanteService.GetAllAsync();
            return Ok(solicitantes);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Solicitante solicitante)
        {
            await _solicitanteService.AddAsync(solicitante);
            return Ok();
        }
    }

}
