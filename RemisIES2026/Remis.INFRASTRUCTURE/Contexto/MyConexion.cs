using MySqlConnector;
using Remis.CORE.Interfaces;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Remis.INFRASTRUCTURE.Contexto
{

    public class MyConexion : IMyConexion
    {
        private readonly string _cadenaDeConexion;

        /* el constructor recibe  la cadena de conexion  desde appsetting.json*/
        public MyConexion(string _cadena)
        {
            _cadenaDeConexion = _cadena;
        }

      
        /* el siguiente método(sincronico) es para obtener una conexion abierta */
        public IDbConnection obtenerConexion()
        {
            MySqlConnection conn = new MySqlConnection(_cadenaDeConexion);
            try
            {                
                conn.Open();
                
            }
            catch (Exception error)
            {
                ArchivoLog.RegistrarErrores(error);
            }
            
            return conn;
        }

        /* el siguiente método(asicronico) es para obtener una conexion abierta */
        public async Task<IDbConnection> obtenerConexionAsync()
        {
            MySqlConnection conn = new MySqlConnection(_cadenaDeConexion);
            try
            {
                await conn.OpenAsync();
                return conn;
            }
            catch (Exception error)
            {
                ArchivoLog.RegistrarErrores(error);
                conn.Dispose();

                throw;
            }           
        }
    }
}
