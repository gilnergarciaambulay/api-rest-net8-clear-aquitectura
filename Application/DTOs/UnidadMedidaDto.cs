using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UnidadMedidaDto
    {
        public string Codigo { get; set; } = default!;
        public string Abreviatura { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Usuario { get; set; } = default!;
        public string FechaCreacion { get; set; }
    }
}
