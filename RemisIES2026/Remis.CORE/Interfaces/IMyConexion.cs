using System.Data;


namespace Remis.CORE.Interfaces
{
    public interface IMyConexion
    {
        IDbConnection obtenerConexion();
        Task<IDbConnection> obtenerConexionAsync();
    }

}
