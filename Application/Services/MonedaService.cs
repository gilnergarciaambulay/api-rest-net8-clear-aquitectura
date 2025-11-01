using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MonedaService: IMonedaService
    {
        private readonly IModenaRepository _monedaRepository;
        private readonly ILogger<MonedaService> _logger;

        public MonedaService(IModenaRepository monedaRepository, ILogger<MonedaService> logger)
        {
            _monedaRepository = monedaRepository;
            _logger = logger;
        }

        public Task<IEnumerable<Moneda>> ObtenerMonedaAsync()
        {
            _logger.LogInformation("Ejecutando caso de uso: Obtener unidades de medida");

            var entidades =  _monedaRepository.GetModenaAsync();

            return entidades;
        }
    }
}
