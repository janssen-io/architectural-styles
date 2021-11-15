using _02_Domain.Models;

namespace _02_Domain
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepo;
        private readonly IShippingService shippingService;

        public OrderService(
            IOrderRepository orderRepo,
            IShippingService shippingService)
        {
            this.orderRepo = orderRepo;
            this.shippingService = shippingService;
        }

        public Shipment PlaceOrder(Order order)
        {
            this.orderRepo.Save(order);
            return this.shippingService.Ship(order);
        }
    }
}
