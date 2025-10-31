using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IUnidadMedidaService _unidadMedidaService;
        private readonly IMonedaService _monedaService;
        private readonly ILogger<PedidosController> _logger;

        public PedidosController(IUnidadMedidaService unidadMedidaService, IMonedaService monedaService, ILogger<PedidosController> logger)
        {
            _unidadMedidaService = unidadMedidaService;
            _monedaService = monedaService;
            _logger = logger;
        }

        [HttpGet("unidades-medida")]
        public async Task<IActionResult> GetUnidadMedida()
        {
            _logger.LogInformation("Solicitud recibida: GET /api/pedidos/unidades-medida");

            var unidades = await _unidadMedidaService.ObtenerUnidadesAsync();

            var response = new ApiResponse<IEnumerable<object>>(
                Message: "Lista de unidades de medida",
                Resultado: unidades
            );

            return Ok(response);
        }

        [HttpGet("monedas")]
        public async Task<IActionResult> GetMonedas()
        {
            _logger.LogInformation("Solicitud recibida: GET /api/pedidos/monedas");
            var monedas = await _monedaService.ObtenerMonedaAsync();
            var response = new ApiResponse<IEnumerable<object>>(
                Message: "Lista de monedas",
                Resultado: monedas
            );
            return Ok(response);
        }
    }
}
