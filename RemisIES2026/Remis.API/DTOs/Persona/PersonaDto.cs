namespace Remis.API.DTOs.Persona
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string? NombreCompleto => $"{Nombre} {Apellido}";
        public string? Dni { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public bool? Activo { get; set; }
        public string? EstadoTexto => Activo == true ? "Activo" : "Inactivo";
    }
}
