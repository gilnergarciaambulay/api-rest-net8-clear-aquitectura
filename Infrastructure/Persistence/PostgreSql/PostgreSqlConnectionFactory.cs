using Infrastructure.Persistence.SqlServer;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.PostgreSql
{
    public class PostgreSqlConnectionFactory
    {
        private readonly string _connectionString;
        private readonly ILogger<PostgreSqlConnectionFactory> _logger;

        public PostgreSqlConnectionFactory(string connectionString, ILogger<PostgreSqlConnectionFactory> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public async Task<NpgsqlConnection> ConnectAsync()
        {
            try
            {
                var connection = new NpgsqlConnection(_connectionString);
                await connection.OpenAsync();
                _logger.LogInformation("Conexión a PostgreSQL establecida correctamente.");
                return connection;
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex, "Error de conexión a PostgreSQL.");
                throw new Exception("No se pudo conectar a la base de datos PostgreSQL.", ex);
            }
        }
    }
}
