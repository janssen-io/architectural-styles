using Microsoft.Extensions.DependencyInjection;

namespace _02_Orders
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
