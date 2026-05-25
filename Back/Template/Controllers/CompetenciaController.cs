using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Competencias;
using Application.DTOs.Request.Competencias;


namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompetenciaController : ControllerBase
    {
        private readonly ICompetenciaService _service;
        public CompetenciaController(ICompetenciaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCompetencia([FromBody] CrearCompetenciaRequest request, CancellationToken ct)
        {
            var response = await _service.CrearCompetencia(request, ct);
            return CreatedAtAction(nameof(ConsultarCompetencia), new { IdCompetencia = response }, response);
        }

        [HttpGet("{IdCompetencia}")]
        public async Task<IActionResult> ConsultarCompetencia(int IdCompetencia, CancellationToken ct)
        {
            var response = await _service.ObtenerCompetenciaPorId(IdCompetencia, ct);
            return Ok(response);
        }

        [HttpPut("{CompetenciaId}")]
        public async Task<IActionResult> ModificarCompetencia([FromBody] ModificarCompetenciaRequest request, CancellationToken ct)
        {
            await _service.ModificarCompetencia(request, ct);
            return NoContent();
        }

        [HttpDelete("{CompetenciaId}")]
        public async Task<IActionResult> EliminarCompetencia(int CompetenciaId)
        {
            await _service.EliminarCompetencia(CompetenciaId);
            return NoContent();
        }
    }
}
