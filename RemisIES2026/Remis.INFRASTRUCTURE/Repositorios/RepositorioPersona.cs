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
        public async Task<IEnumerable<Persona>> BuscarPersona(string buscar_)
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_buscar";


                IDbDataParameter parametro = _comando.CreateParameter();
                parametro.ParameterName = "@_buscar";
                parametro.Value = buscar_;
                _comando.Parameters.Add(parametro);

                using IDataReader reader = _comando.ExecuteReader();

                List<Persona> listaPersonas = new List<Persona>();

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

                    listaPersonas.Add(persona);
                }

                return listaPersonas;
            }
            catch (MySqlException error)
            {
                ArchivoLog.RegistrarErrores(error);
                return Enumerable.Empty<Persona>();
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

       

        public async Task<int> CrearAsync(Persona persona_)
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_crear";
           
                IDbDataParameter parametroApellido = _comando.CreateParameter();
                parametroApellido.ParameterName = "@_apellido";
                parametroApellido.Value = persona_.Apellido;
                _comando.Parameters.Add(parametroApellido);

                IDbDataParameter parametroNombre = _comando.CreateParameter();
                parametroNombre.ParameterName = "@_nombre";
                parametroNombre.Value = persona_.Nombre;
                _comando.Parameters.Add(parametroNombre);

                IDbDataParameter parametroDni = _comando.CreateParameter();
                parametroDni.ParameterName = "@_dni";
                parametroDni.Value = persona_.Dni;
                _comando.Parameters.Add(parametroDni);

                IDbDataParameter parametroTelefono = _comando.CreateParameter();
                parametroTelefono.ParameterName = "@_telefono";
                parametroTelefono.Value = persona_.Telefono;
                _comando.Parameters.Add(parametroTelefono);

                IDbDataParameter parametroEmail = _comando.CreateParameter();
                parametroEmail.ParameterName = "@_email";
                parametroEmail.Value = persona_.Email;
                _comando.Parameters.Add(parametroEmail);

                IDbDataParameter parametroDireccion = _comando.CreateParameter();
                parametroDireccion.ParameterName = "@_direccion";
                parametroDireccion.Value = persona_.Direccion;
                _comando.Parameters.Add(parametroDireccion);

                IDbDataParameter parametroFechaAlta = _comando.CreateParameter();
                parametroFechaAlta.ParameterName = "@_fecha_alta";
                parametroFechaAlta.Value = persona_.FechaAlta;
                _comando.Parameters.Add(parametroFechaAlta);

                IDbDataParameter parametroActivo = _comando.CreateParameter();
                parametroActivo.ParameterName = "@_activo";
                parametroActivo.Value = persona_.Activo;
                _comando.Parameters.Add(parametroActivo);

                
                int resultado = Convert.ToInt32(_comando.ExecuteScalar());
                                
                return (resultado);
            }
            catch (MySqlException error)
            {
                ArchivoLog.RegistrarErrores(error);
                return 0;
            }
        }

        public Task<bool> EliminarAsync(int id_)
        {
            throw new NotImplementedException();
        }
   
    }
}
