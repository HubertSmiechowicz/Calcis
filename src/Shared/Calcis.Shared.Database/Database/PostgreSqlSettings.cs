using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Database
{
    public class PostgreSqlSettings
    {
        public string WriteConnectionString { get; set; } = string.Empty;
        public string ReadConnectionString { get; set; } = string.Empty;
    }
}
