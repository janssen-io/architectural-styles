using Microsoft.Extensions.DependencyInjection;

namespace _03_Shipping
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddShippingServices(this IServiceCollection services)
        {
            services.AddTransient<IShippingService, ShippingService>();
            return services;
        }
    }
}
