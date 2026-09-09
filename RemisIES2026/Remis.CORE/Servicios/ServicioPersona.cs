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
    }
}
