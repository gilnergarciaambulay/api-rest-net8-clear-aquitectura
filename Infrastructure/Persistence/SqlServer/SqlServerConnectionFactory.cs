using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SqlServer
{
    public class SqlServerConnectionFactory
    {
        private readonly string _connectionString;
        private readonly ILogger<SqlServerConnectionFactory> _logger;

        public SqlServerConnectionFactory(string connectionString, ILogger<SqlServerConnectionFactory> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<SqlConnection> ConnectAsync()
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                _logger.LogInformation("Conexión a SQL Server establecida correctamente.");
                return connection;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de conexión a la base de datos.");
                throw new Exception("No se pudo conectar a la base de datos.", ex);
            }
        }
    }
}
