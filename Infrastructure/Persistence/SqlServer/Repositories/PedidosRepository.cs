using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SqlServer.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly SqlServerConnectionFactory _sqlServerFactory;
        private readonly ILogger<PedidosRepository> _logger;

        public PedidosRepository(SqlServerConnectionFactory sqlServerFactory, ILogger<PedidosRepository> logger)
        {
            _sqlServerFactory = sqlServerFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<UnidadMedida>> GetUnidadMedidaAsync()
        {
            var lista = new List<UnidadMedida>();

            try
            {
                await using var conn = await _sqlServerFactory.ConnectAsync();
                await using var cmd = new SqlCommand("ERP_GET_PED_READ_UNIDADMEDIDA", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    lista.Add(new UnidadMedida
                    {
                        CodUniMedida = reader["CodUniMedida"]?.ToString() ?? string.Empty,
                        AbvUniMedida = reader["AbvUniMedida"]?.ToString() ?? string.Empty,
                        NomUniMedida = reader["NomUniMedida"]?.ToString() ?? string.Empty,
                        Usuario = reader["Usuario"]?.ToString() ?? string.Empty,
                        FchCrea = reader["FchCrea"]?.ToString() ?? string.Empty
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
