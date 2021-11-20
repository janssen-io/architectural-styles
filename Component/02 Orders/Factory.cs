using _03_Shipping;

namespace _02_Orders
{
    public static class Factory
    {
        public static IOrderService CreateOrderService(IShippingService shippingService)
        {
            return new OrderService(shippingService);
        }
    }
}
