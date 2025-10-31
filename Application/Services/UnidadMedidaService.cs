using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IPedidosRepository _pedidosRepository;
        private readonly ILogger<UnidadMedidaService> _logger;

        public UnidadMedidaService(IPedidosRepository pedidosRepository, ILogger<UnidadMedidaService> logger)
        {
            _pedidosRepository = pedidosRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<UnidadMedidaDto>> ObtenerUnidadesAsync()
        {
            _logger.LogInformation("Ejecutando caso de uso: Obtener unidades de medida");

            var entidades = await _pedidosRepository.GetUnidadMedidaAsync();

            return entidades.Select(u => new UnidadMedidaDto
            {
                Codigo = u.CodUniMedida,
                Abreviatura = u.AbvUniMedida,
                Nombre = u.NomUniMedida,
                Usuario = u.Usuario,
                FechaCreacion = u.FchCrea
            }).ToList();
        }
    }
}
