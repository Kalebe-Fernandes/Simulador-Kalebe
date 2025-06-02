using Microsoft.Extensions.Logging;

namespace SimuladorCredito.Application.Logging
{
    public class CustomerLogger(CustomLoggerProviderConfiguration loggerConfig) : ILogger
    {
        readonly CustomLoggerProviderConfiguration _loggerConfig = loggerConfig;

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        { 
            return null; // No scope management implemented
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // Check if the log level is enabled based on the configuration
            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var mensagem = $"{logLevel}: {eventId.Id} - {formatter(state, exception)}";
            EscreverTextoNoArquivo(mensagem);
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            var caminhoArquivoLog = Path.Combine(AppContext.BaseDirectory, "Log.txt");
            using var streamWriter = new StreamWriter(caminhoArquivoLog, true);
            try
            {
                streamWriter.WriteLine(mensagem);
                streamWriter.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
