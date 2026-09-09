using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Remis.CORE.Entidades
{
    [Table("personas")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPersona")]
        public int IdPersona { get; set; }

        [Column("apellido")]
        [MaxLength(50)]
        public string? Apellido { get; set; }

        [Column("nombre")]
        [MaxLength(50)]
        public string? Nombre { get; set; }

        [Column("dni")]
        [MaxLength(10)]
        public string? Dni { get; set; }

        [Column("telefono")]
        [MaxLength(20)]
        public string? Telefono { get; set; }

        [Column("email")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string? Email { get; set; }

        [Column("direccion")]
        [MaxLength(100)]
        public string? Direccion { get; set; }

        [Column("fecha_alta")]
        public DateTime? FechaAlta { get; set; }

        [Column("activo")]
        public bool? Activo { get; set; }
    }
}
