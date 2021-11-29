using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShippingRepository, ShippingRepository>();
        }
    }
}
