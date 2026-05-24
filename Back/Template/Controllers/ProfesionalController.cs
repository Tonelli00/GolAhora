using Application.DTOs.Request.Profesional;
using Application.Interfaces.Profesionales;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfesionalesController : ControllerBase
    {
        private readonly IProfesionalService _profesionalService;

        public ProfesionalesController(IProfesionalService profesionalService)
        {
            _profesionalService = profesionalService;
        }

        // RF46: REGISTRAR
        [HttpPost("profesores")]
        public async Task<IActionResult> RegistrarProfesor([FromBody] RegistrarProfesorRequest request)
        {
            var resultado = await _profesionalService.RegistrarProfesor(request);
            return CreatedAtAction(nameof(ConsultarProfesorPorDni), new { dni = resultado.Dni }, resultado);
        }

        [HttpPost("entrenadores")]
        public async Task<IActionResult> RegistrarEntrenador([FromBody] RegistrarEntrenadorRequest request)
        {
            var resultado = await _profesionalService.RegistrarEntrenador(request);
            return CreatedAtAction(nameof(ConsultarEntrenadorPorDni), new { dni = resultado.Dni }, resultado);
        }

        // RF47: MODIFICAR
        [HttpPatch("profesores/{dni}")]
        public async Task<IActionResult> ModificarProfesor([FromRoute] int dni, [FromBody] RegistrarProfesorRequest request)
        {
            var resultado = await _profesionalService.ModificarProfesor(dni, request);
            return Ok(resultado);
        }

        [HttpPatch("entrenadores/{dni}")]
        public async Task<IActionResult> ModificarEntrenador([FromRoute] int dni, [FromBody] RegistrarEntrenadorRequest request)
        {
            var resultado = await _profesionalService.ModificarEntrenador(dni, request);
            return Ok(resultado);
        }

        // RF48: CONSULTAR POR DNI
        [HttpGet("profesores/{dni}")]
        public async Task<IActionResult> ConsultarProfesorPorDni([FromRoute] int dni)
        {
            var resultado = await _profesionalService.ConsultarProfesorPorDni(dni);
            return Ok(resultado);
        }

        [HttpGet("entrenadores/{dni}")]
        public async Task<IActionResult> ConsultarEntrenadorPorDni([FromRoute] int dni)
        {
            var resultado = await _profesionalService.ConsultarEntrenadorPorDni(dni);
            return Ok(resultado);
        }

        // RF48: LISTAR TODOS
        [HttpGet("profesores")]
        public async Task<IActionResult> ConsultarTodosLosProfesores()
        {
            var resultado = await _profesionalService.ConsultarTodosLosProfesores();
            return Ok(resultado);
        }

        [HttpGet("entrenadores")]
        public async Task<IActionResult> ConsultarTodosLosEntrenadores()
        {
            var resultado = await _profesionalService.ConsultarTodosLosEntrenadores();
            return Ok(resultado);
        }

        // RF49: ELIMINAR 
        [HttpDelete("profesores/{dni}")]
        public async Task<IActionResult> EliminarProfesor([FromRoute] int dni)
        {
            var resultado = await _profesionalService.EliminarProfesor(dni);
            return Ok(resultado);
        }

        [HttpDelete("entrenadores/{dni}")]
        public async Task<IActionResult> EliminarEntrenador([FromRoute] int dni)
        {
            var resultado = await _profesionalService.EliminarEntrenador(dni);
            return Ok(resultado);
        }

        // RF50: IMPRIMIR
        [HttpGet("{dni}/ficha")]
        public async Task<IActionResult> ImprimirFichaProfesional([FromRoute] int dni, [FromQuery] string tipoProfesional)
        {
            var jsonResult = await _profesionalService.ImprimirFichaProfesional(dni, tipoProfesional);
            return Content(jsonResult, "application/json");
        }

        // RF51: ASIGNAR PROFESIONALES A CLIENTES
        [HttpPost("asignar-cliente")]
        public async Task<IActionResult> AsignarClienteAProfesional([FromQuery] int profesionalDni, [FromQuery] int clienteId, [FromQuery] double precio)
        {
            var resultado = await _profesionalService.AsignarClienteAProfesional(profesionalDni, clienteId, precio);
            return Ok(resultado);
        }

        // RF52: VERIFICAR CERTIFICACIÓN DEPORTIVA
        [HttpPatch("{dni}/verificar-certificacion")]
        public async Task<IActionResult> VerificarCertificacion([FromRoute] int dni, [FromQuery] string tipoProfesional, [FromQuery] bool aprobado)
        {
            var resultado = await _profesionalService.VerificarCertificacion(dni, tipoProfesional, aprobado);
            return Ok(resultado);
        }
    }
}
