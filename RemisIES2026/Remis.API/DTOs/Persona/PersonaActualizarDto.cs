namespace Remis.API.DTOs.Persona
{
    public class PersonaActualizarDto
    {
        public int IdPersona { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string? Dni { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public bool? Activo { get; set; }
    }
}
