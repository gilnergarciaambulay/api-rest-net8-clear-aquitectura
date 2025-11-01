using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Persistence.PostgreSql;
using Infrastructure.Persistence.SqlServer;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración común
            services.AddSingleton<DatabaseSettings>();

            // Leemos el proveedor de la configuración
            var provider = configuration["DatabaseProvider"];

            // Repositorios SQL Server comunes
            services.AddScoped(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<SqlServerConnectionFactory>>();
                var config = provider.GetRequiredService<DatabaseSettings>();
                var connectionString = config.GetSqlServerConnectionString();
                return new SqlServerConnectionFactory(connectionString, logger);
            });

            services.AddScoped<IPedidosRepository, Infrastructure.Persistence.SqlServer.Repositories.PedidosRepository>();


            // Ahora decides qué MonedaRepository usar:
            if (provider == "PostgreSQL")
            {
                // PostgreSQL
                services.AddScoped(provider =>
                {
                    var logger = provider.GetRequiredService<ILogger<PostgreSqlConnectionFactory>>();
                    var config = provider.GetRequiredService<DatabaseSettings>();
                    var connectionString = config.GetPostgreSqlConnectionString();
                    return new PostgreSqlConnectionFactory(connectionString, logger);
                });

                services.AddScoped<IModenaRepository, Infrastructure.Persistence.PostgreSql.Repositories.MonedaRepository>();
            }
            else
            {
                // SQL Server
                services.AddScoped<IModenaRepository, Infrastructure.Persistence.SqlServer.Repositories.MonedaRepository>();
            }

            return services;
        }
    }
}
