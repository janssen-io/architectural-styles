using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class IServiceCollectionExtensions
    {
        public static void AddLayeredServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShippingService, ShippingService>();
        }
    }
}
