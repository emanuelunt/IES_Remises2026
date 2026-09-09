using Remis.CORE.Entidades;

namespace Remis.CORE.Interfaces
{
    public interface IRepositorioPersona
    {
        Task<IEnumerable<Persona>> ObtenerTodosAsync();
        Task<IEnumerable<Persona>> BuscarPersona(string buscar_);
        Task<Persona> ObtenerPorIdAsync(int id_);
        Task<Persona> ObtenerPorDniAsync(string dni_);
        Task<int> CrearAsync(Persona persona_);
        Task<bool> ActualizarAsync(Persona persona_);
        Task<bool> EliminarAsync(int id_);
        Task<bool> ExisteDniAsync(string dni_);
        Task<bool> ExisteEmailAsync(string email_);
    }
}
