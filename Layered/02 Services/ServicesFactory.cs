using Infrastructure;

namespace Services
{
    public static class ServicesFactory
    {
        public static IOrderService CreateOrderService(
            IOrderRepository orderRepo,
            IShippingService shippingService)
        {
            return new OrderService(orderRepo, shippingService);
        }

        public static IShippingService CreateShippingService(
            IShippingRepository shippingRepo)
        {
            return new ShippingService(shippingRepo);
        }
    }
}
