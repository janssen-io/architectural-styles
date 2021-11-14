using System;
using System.Collections.Generic;
using _03_Shipping;
using Microsoft.AspNetCore.Mvc;

namespace _02_Orders
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        private readonly Dictionary<Guid, Order> orders = new();
        private readonly IShippingService shippingService;

        public OrderController(IShippingService shippingService)
        {
            this.shippingService = shippingService;
        }

        public Order Get(Guid orderId)
        {
            return this.orders[orderId];
        }

        public Guid PlaceOrder(decimal totalPrice)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = totalPrice,
            };

            this.orders.Add(order.Id, order);
            shippingService.Ship(order.Id);

            // alternatively, we could return the shipment id
            // but as this is the order slice, it feels more natural to return the order id
            // we can use it to retrieve more details about the order
            return order.Id;
        }
    }
}
