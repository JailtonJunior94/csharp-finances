using Finances.Business.Domain.Interfaces;
using Finances.Business.Infra.Repositories;
using Finances.Business.Application.Services;
using Finances.Business.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Finances.API.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            /* Services */
            services.AddScoped<IFinanceService, FinanceService>();

            /* Repositories */
            services.AddScoped<IFinanceRepository, FinanceRepository>();
        }
    }
}
