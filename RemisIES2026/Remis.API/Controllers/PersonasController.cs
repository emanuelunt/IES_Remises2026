using Microsoft.AspNetCore.Mvc;
using Remis.API.DTOs.Persona;
using Remis.CORE.Entidades;
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

        // GET: api/personas/buscar?termino=juan
        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string termino)
        {            
                var personas = await _servicio.BuscarAsync(termino);
                return Ok(personas);            
        }

        // POST: api/personas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonaCrearDto dto)
        {
              
                Persona persona = new Persona
                {
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Email = dto.Email,
                    Direccion = dto.Direccion
                };

                int id = await _servicio.CrearAsync(persona);
                persona.IdPersona = id;

               PersonaDto nuevaPersona = new PersonaDto
                {
                    IdPersona = persona.IdPersona,
                    Apellido = persona.Apellido ?? string.Empty,
                    Nombre = persona.Nombre ?? string.Empty,                    
                    Dni = persona.Dni,
                    Telefono = persona.Telefono,
                    Email = persona.Email,
                    Direccion = persona.Direccion,
                    FechaAlta = persona.FechaAlta,
                    Activo = persona.Activo
                };

                return CreatedAtAction(nameof(GetById), new { id }, nuevaPersona);
         }          
    }
}
