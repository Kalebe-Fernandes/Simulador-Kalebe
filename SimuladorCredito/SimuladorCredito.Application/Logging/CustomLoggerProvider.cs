using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace SimuladorCredito.Application.Logging
{
    public class CustomLoggerProvider(CustomLoggerProviderConfiguration config) : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration _config = config ?? throw new ArgumentNullException(nameof(config));
        readonly ConcurrentDictionary<string, CustomerLogger> _loggers = new();

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomerLogger(_config)); ;
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
