using System.ComponentModel.DataAnnotations;

namespace Remis.API.DTOs.Persona
{
    public class PersonaCrearDto
    {        
        public string Apellido { get; set; }     
        public string Nombre { get; set; }        
        public string? Dni { get; set; }        
        public string? Telefono { get; set; }        
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        
    }
}
