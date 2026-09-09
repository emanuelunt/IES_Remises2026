using Microsoft.AspNetCore.Mvc;
using Remis.CORE.Servicios;

namespace Remis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ServicioPersona _servicio;

        public PersonasController(ServicioPersona servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _servicio.AllAsync();
            return Ok(personas);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _servicio.GetByIdAsync(id);
            if (persona == null)
                return NotFound();
            return Ok(persona);
        }

        [HttpGet("dni/{dni}")]
        public async Task<IActionResult> GetByDni(string dni)
        {
            var persona = await _servicio.GetByDniAsync(dni);
            if (persona == null)
                return NotFound();
            return Ok(persona);
        }
    }
}
