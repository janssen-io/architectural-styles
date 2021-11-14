using Infrastructure;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
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
            this.orderRepo.Save(new Infrastructure.Models.Order {
                Id = order.Id,
                TotalPrice = order.TotalPrice
            });

            return this.shippingService.Ship(order);
        }
    }
}
