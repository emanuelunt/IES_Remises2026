using MySqlConnector;
using Remis.CORE.Entidades;
using Remis.CORE.Interfaces;
using Remis.INFRASTRUCTURE.Contexto;
using System.Data;

namespace Remis.INFRASTRUCTURE.Repositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly IMyConexion _conn;

        public RepositorioPersona(IMyConexion conn)
        {
            _conn = conn;
        }
        public async Task<IEnumerable<Persona>> ObtenerTodosAsync()
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_obtener_todos";

                using IDataReader reader = _comando.ExecuteReader();

                List<Persona> ListaPersonas = new List<Persona>();

                while (reader.Read())
                {
                    Persona persona = new Persona();

                    persona.IdPersona = reader.GetInt32(0);
                    persona.Apellido = reader.GetString(1);
                    persona.Nombre = reader.GetString(2);
                    persona.Dni = reader.GetString(3);
                    persona.Telefono = reader.GetString(4);
                    persona.Email = reader.GetString(5);
                    persona.Direccion = reader.GetString(6);
                    persona.FechaAlta = reader.GetDateTime(7);
                    persona.Activo = reader.GetBoolean(8);

                    ListaPersonas.Add(persona);
                }

                return ListaPersonas;
            }
            catch (MySqlException error)
            {
                ArchivoLog.RegistrarErrores(error);
                return Enumerable.Empty<Persona>();
            }
        }
        public async Task<Persona> ObtenerPorIdAsync(int id_)
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_obtener_por_id";
                IDbDataParameter parametro = _comando.CreateParameter();
                parametro.ParameterName = "@_id";
                parametro.Value = id_;
                _comando.Parameters.Add(parametro);

                using IDataReader reader =  _comando.ExecuteReader();

                Persona persona = new Persona();

                if (reader.Read())
                {
                    persona.IdPersona = reader.GetInt32(0);
                    persona.Apellido = reader.GetString(1);
                    persona.Nombre = reader.GetString(2);
                    persona.Dni = reader.GetString(3);
                    persona.Telefono = reader.GetString(4);
                    persona.Email = reader.GetString(5);
                    persona.Direccion = reader.GetString(6);
                    persona.FechaAlta = reader.GetDateTime(7);
                    persona.Activo = reader.GetBoolean(8);
                    return persona;
                }

                return null;
            }
            catch (MySqlException error)
            {
                ArchivoLog.RegistrarErrores(error);
                return null;
            }
        }
        public async Task<Persona> ObtenerPorDniAsync(string dni_)
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_obtener_por_dni";
                IDbDataParameter parametro = _comando.CreateParameter();
                parametro.ParameterName = "_dni";
                parametro.Value = dni_;
                _comando.Parameters.Add(parametro);

                using IDataReader reader = _comando.ExecuteReader();

                Persona persona = new Persona();

                if (reader.Read())
                {
                    persona.IdPersona = reader.GetInt32(0);
                    persona.Apellido = reader.GetString(1);
                    persona.Nombre = reader.GetString(2);
                    persona.Dni = reader.GetString(3);
                    persona.Telefono = reader.GetString(4);
                    persona.Email = reader.GetString(5);
                    persona.Direccion = reader.GetString(6);
                    persona.FechaAlta = reader.GetDateTime(7);
                    persona.Activo = reader.GetBoolean(8);
                    return persona;
                }

                return null;
            }
            catch (MySqlException error)
            {
                ArchivoLog.RegistrarErrores(error);
                return null;
            }
        }
        public Task<bool> ExisteDniAsync(string dni_)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteEmailAsync(string email_)
        {
            throw new NotImplementedException();
        }       
        public Task<bool> ActualizarAsync(Persona persona_)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persona>> BuscarPersona(string buscar_)
        {
            throw new NotImplementedException();
        }

        public Task<int> CrearAsync(Persona persona_)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id_)
        {
            throw new NotImplementedException();
        }
   
    }
}
