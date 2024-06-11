using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure.Logging
{
    public class Logger<T>
    {
        private readonly ILogger<T> _logger;

        public Logger(ILogger<T> logger) 
        {
            _logger = logger;
        }

        public void LogError(Exception exception, string message)
        {
            _logger.LogError(exception, message);
        }

        public void LogWarning(Exception exception, string message)
        {
            _logger.LogWarning(exception, message);
        }

        public void LogInformation(Exception exception, string message)
        {
            _logger.LogInformation(exception, message);
        }
    }
}
