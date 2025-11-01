using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DatabaseSettings
    {
        private readonly IConfiguration _configuration;
        public DatabaseSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSqlServerConnectionString()
        {
            //return _configuration.GetConnectionString("SqlServerConnection")
            //       ?? throw new InvalidOperationException("No se encontró la cadena de conexión.");
            var connection = _configuration.GetConnectionString("SqlServerConnection");
            if (string.IsNullOrWhiteSpace(connection))
                throw new InvalidOperationException("No se encontró la cadena de conexión para SQL Server.");
            return connection;
        }

        public string GetPostgreSqlConnectionString()
        {
            var connection = _configuration.GetConnectionString("PostgreSqlConnection");
            if (string.IsNullOrWhiteSpace(connection))
                throw new InvalidOperationException("No se encontró la cadena de conexión para PostgreSQL.");
            return connection;
        }
    }
}
