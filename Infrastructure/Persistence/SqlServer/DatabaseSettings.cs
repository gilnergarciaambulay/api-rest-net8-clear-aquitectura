using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SqlServer
{
    public class DatabaseSettings
    {
        private readonly IConfiguration _configuration;
        public DatabaseSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection")
                   ?? throw new InvalidOperationException("No se encontró la cadena de conexión.");
        }
    }
}
