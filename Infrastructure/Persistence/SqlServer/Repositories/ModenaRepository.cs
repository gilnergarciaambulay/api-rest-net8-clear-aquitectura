using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SqlServer.Repositories
{
    public class ModenaRepository : IModenaRepository
    {
        private readonly SqlServerConnectionFactory _sqlServerFactory;
        private readonly ILogger<ModenaRepository> _logger;

        public ModenaRepository(SqlServerConnectionFactory sqlServerFactory, ILogger<ModenaRepository> logger)
        {
            _sqlServerFactory = sqlServerFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<Modeda>> GetModenaAsync()
        {
            var lista = new List<Modeda>();

            try
            {
                await using var conn = await _sqlServerFactory.ConnectAsync();
                await using var cmd = new SqlCommand("ERP_GET_PED_READ_ERP_LOG_MONEDA", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    lista.Add(new Modeda
                    {
                        CodMoneda = reader["CodMoneda"]?.ToString() ?? string.Empty,
                        AbvMoneda = reader["AbvMoneda"]?.ToString() ?? string.Empty,
                        SimMoneda = reader["SimMoneda"]?.ToString() ?? string.Empty
                    });
                }

                _logger.LogInformation("Consulta de unidades de medida ejecutada correctamente ({Count} registros).", lista.Count);
                return lista;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error SQL al obtener unidades de medida");
                throw new Exception("Error al obtener las unidades de medida desde la base de datos.", ex);
            }
        }
    }
}
