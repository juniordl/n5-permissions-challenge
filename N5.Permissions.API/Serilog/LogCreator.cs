using Serilog;
using Serilog.Enrichers;
using Serilog.Events;

namespace N5.Permissions.API.Serilog
{
    public class LogCreator
    {
        public LogCreator()
        {
            ConfigureLogging();
        }

        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.With(new ThreadIdEnricher())
                .WriteTo.Console(
                    outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
