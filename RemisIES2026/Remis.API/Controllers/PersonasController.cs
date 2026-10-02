using FluentValidation;
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
        private IValidator<PersonaCrearDto> _validatorCrearPersona;
        private IValidator<PersonaActualizarDto> _validatorActualizarPersona;

        public PersonasController(ServicioPersona servicio,
            IValidator<PersonaCrearDto> validatorCrearPersona, IValidator<PersonaActualizarDto> validatorActualizarPersona)
        {
            _servicio = servicio;
            _validatorCrearPersona = validatorCrearPersona;
            _validatorActualizarPersona = validatorActualizarPersona;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _servicio.AllAsync();
            return Ok(personas);
        }

        [HttpGet("{id:int}")] // api/personas/5 , parametro de ruta
        public async Task<IActionResult> GetById([FromRoute] int id)
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

        // GET: api/personas/buscar?termino=juan , parametro de query string
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
              
            var validationResultado = await _validatorCrearPersona.ValidateAsync(dto);

            if (!validationResultado.IsValid)
            {
                 var errores = validationResultado.Errors.Select(e => e.ErrorMessage).ToList();
                 return BadRequest(new { Mensaje = "Error de validación", Errores = errores });              
            }

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
        } // Finn create
         
        // PUT: api/personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonaActualizarDto dto)
        {

            
            var validationResultado = await _validatorActualizarPersona.ValidateAsync(dto);

            if (!validationResultado.IsValid)
            {
                 var errores = validationResultado.Errors.Select(e => e.ErrorMessage).ToList();
                 return BadRequest(new { Mensaje = "Error de validación", Errores = errores });              
            }

            if (id != dto.IdPersona)
                return BadRequest(new { Mensaje = "El ID de la URL no coincide con el ID del cuerpo" });

                //Convertir DTO -> Entidad
                Persona persona = new Persona
                {
                    IdPersona = dto.IdPersona,
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Email = dto.Email,
                    Direccion = dto.Direccion,
                    Activo = dto.Activo
                };

                //  Llamar al servicio
                bool actualizado = await _servicio.ActualizarAsync(persona);
                if (!actualizado)
                    return NotFound(new { Mensaje = $"No se encontró la persona con ID {id}" });

                // Convertir Entidad -> DTO Response
                PersonaDto personaActualizada = new PersonaDto
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

                return Ok(personaActualizada);
        } // Fin update

        // DELETE: api/personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {        
            Console.WriteLine($"Eliminando persona con ID {id}");
            bool eliminado = await _servicio.EliminarAsync(id);
             if (!eliminado)
                 return NotFound(new { Mensaje = $"No se encontró la persona con ID {id}" });
             return NoContent(); // 204           
        }
    }    
}
