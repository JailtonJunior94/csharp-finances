using Finances.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Finances.API.Configurations
{
    public static class LogConfiguration
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
