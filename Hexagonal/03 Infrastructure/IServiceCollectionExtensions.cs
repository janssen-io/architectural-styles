using _02_Domain;
using Microsoft.Extensions.DependencyInjection;

namespace _03_Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShippingRepository, ShippingRepository>();
        }
    }
}
