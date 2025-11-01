using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.PostgreSql.Repositories
{
    public class MonedaRepository : IModenaRepository
    {
        private readonly PostgreSqlConnectionFactory _pgFactory;
        private readonly ILogger<MonedaRepository> _logger; 
        public MonedaRepository(PostgreSqlConnectionFactory pgFactory, ILogger<MonedaRepository> logger)
        {
            _pgFactory = pgFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<Moneda>> GetModenaAsync()
        {
            var monedas = new List<Moneda>();
            try
            {
                await using var connection = await _pgFactory.ConnectAsync();
                var query = "SELECT * FROM FUNCTION_GET_ERP_MONEDA()";
                await using var command = new Npgsql.NpgsqlCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var moneda = new Moneda
                    {
                        CodMoneda = reader.GetInt32(0).ToString(),
                        AbvMoneda = reader.GetString(1),
                        SimMoneda = reader.GetString(2)
                    };
                    monedas.Add(moneda);
                }
                _logger.LogInformation("Se obtuvieron {Count} monedas de la base de datos.", monedas.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las monedas de la base de datos.");
                throw;
            }
            return monedas;
        }
    }
}
