using Microsoft.Extensions.DependencyInjection;

namespace _02_Domain
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShippingService, ShippingService>();
        }
    }
}
