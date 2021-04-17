using CostCalculator.Domain.Services;
using CostCalculator.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace CostCalculator
{
    public static class IocRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICartFactory, CartFactory>();
            services.AddTransient<IWatchRepository, WatchRepository>();
        }
    }
}