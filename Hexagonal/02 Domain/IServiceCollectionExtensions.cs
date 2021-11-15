using Microsoft.Extensions.DependencyInjection;

namespace _02_Domain
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDomain(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShippingService, ShippingService>();
            return services;
        }
    }
}
