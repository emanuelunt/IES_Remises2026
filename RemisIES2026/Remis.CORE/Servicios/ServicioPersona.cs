using Remis.CORE.Entidades;
using Remis.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remis.CORE.Servicios
{
    public class ServicioPersona
    {
        private readonly IRepositorioPersona _repositorio;

        public ServicioPersona(IRepositorioPersona repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Persona>> AllAsync()
        {
            return await _repositorio.ObtenerTodosAsync();
        }
        public async Task<Persona> GetByIdAsync(int _id)
        {
            if (_id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0");
            return await _repositorio.ObtenerPorIdAsync(_id);
        }
        public async Task<Persona> GetByDniAsync(string _dni)
        {
            if (string.IsNullOrWhiteSpace(_dni))
                throw new ArgumentException("El DNI no puede estar vacío");

            return await _repositorio.ObtenerPorDniAsync(_dni);
        }

        public async Task<IEnumerable<Persona>> BuscarAsync(string _buscar)
        {
            if (string.IsNullOrWhiteSpace(_buscar))
                throw new ArgumentException("El término de búsqueda no puede estar vacío");
                        
            if (_buscar.Trim().Length < 2)
                throw new ArgumentException("El término de búsqueda debe tener al menos 2 caracteres");

            return await _repositorio.BuscarPersona(_buscar.Trim());
        }

        public async Task<int> CrearAsync(Persona _persona)
        {
           
            if (_persona == null)
                throw new ArgumentNullException(nameof(_persona), "La persona no puede ser nula");
          
            if (string.IsNullOrWhiteSpace(_persona.Apellido))
                throw new ArgumentException("El apellido es obligatorio");

            if (string.IsNullOrWhiteSpace(_persona.Nombre))
                throw new ArgumentException("El nombre es obligatorio");

            if (!string.IsNullOrWhiteSpace(_persona.Apellido) && _persona.Apellido.Length > 50)
                throw new ArgumentException("El apellido no puede tener más de 50 caracteres");

            if (!string.IsNullOrWhiteSpace(_persona.Nombre) && _persona.Nombre.Length > 50)
                throw new ArgumentException("El nombre no puede tener más de 50 caracteres");

            if (!string.IsNullOrWhiteSpace(_persona.Dni) && _persona.Dni.Length > 10)
                throw new ArgumentException("El DNI no puede tener más de 10 caracteres");

            if (!string.IsNullOrWhiteSpace(_persona.Telefono) && _persona.Telefono.Length > 20)
                throw new ArgumentException("El teléfono no puede tener más de 20 caracteres");

            if (!string.IsNullOrWhiteSpace(_persona.Email) && _persona.Email.Length > 100)
                throw new ArgumentException("El email no puede tener más de 100 caracteres");

            if (!string.IsNullOrWhiteSpace(_persona.Direccion) && _persona.Direccion.Length > 100)
                throw new ArgumentException("La dirección no puede tener más de 100 caracteres");

            
            //if (!string.IsNullOrWhiteSpace(_persona.Dni))
            //{
            //    if (await _repositorio.ExisteDniAsync(_persona.Dni))
            //        throw new InvalidOperationException($"Ya existe una persona con el DNI {_persona.Dni}");
            //}

            
            //if (!string.IsNullOrWhiteSpace(_persona.Email))
            //{
            //    if (await _repositorio.ExisteEmailAsync(_persona.Email))
            //        throw new InvalidOperationException($"Ya existe una persona con el email {_persona.Email}");
            //}
           
            _persona.FechaAlta = DateTime.Now;
            _persona.Activo = true;
            
            return await _repositorio.CrearAsync(_persona);
        }

      
    }
}

