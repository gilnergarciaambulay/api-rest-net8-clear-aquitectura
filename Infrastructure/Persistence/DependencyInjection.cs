using Application.Interfaces;
using Core.Interfaces;
using Infrastructure.Persistence.SqlServer;
using Infrastructure.Persistence.SqlServer.Repositories;
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
            services.AddSingleton<DatabaseSettings>();

            services.AddScoped(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<SqlServerConnectionFactory>>();
                var config = provider.GetRequiredService<DatabaseSettings>();
                var connectionString = config.GetConnectionString();
                return new SqlServerConnectionFactory(connectionString, logger);
            });

            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IModenaRepository, ModenaRepository>();
            return services;
        }
    }
}
