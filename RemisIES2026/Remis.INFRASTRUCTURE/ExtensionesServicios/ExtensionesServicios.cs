
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Remis.CORE.Interfaces;
using Remis.CORE.Servicios;
using Remis.INFRASTRUCTURE.Contexto;
using Remis.INFRASTRUCTURE.Repositorios;

namespace Remis.INFRASTRUCTURE.ExtensionesServicios
{
    
    public static class ExtensionesServicios
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,  
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "La cadena de conexión 'DefaultConnection' no está configurada."
                );

            services.AddSingleton<IMyConexion>(new MyConexion(connectionString));

            services.AddScoped<IRepositorioPersona, RepositorioPersona>();
            services.AddScoped<ServicioPersona>();
                       

            return services;
        }
    }
}

