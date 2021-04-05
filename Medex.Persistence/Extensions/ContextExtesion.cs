using Microsoft.Extensions.Configuration;

namespace Medex.Persistence.Extensions
{
    public static class ContextExtesion
    {
        public static string BuildConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("SqlServerConnection:ConnectionString")
               + $"Database={configuration.GetConnectionString("SqlServerConnection:Database")};";
    }
}
