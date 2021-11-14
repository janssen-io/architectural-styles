using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterLayeredServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShippingService, ShippingService>();
            return services;
        }
    }
}
