using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure.Database
{
    public class MongoDbSettings
    {
        public string WriteConnectionString { get; set; } = string.Empty;
        public string WriteDatabase { get; set; } = string.Empty;
        public string ReadConnectionString { get; set; } = string.Empty;
        public string ReadDatabase { get; set; } = string.Empty;
    }
}
