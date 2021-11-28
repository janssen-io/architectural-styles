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
        private readonly IShippingController _shippingController;
        private readonly Dictionary<Guid, Order> orders = new();

        // It's rare that controllers have dependencies on other controllers.
        // A more common approach would be to use Mediatr.
        // Then the dependency could also be inverted as this Order project
        // would send out a 'OrderPlaced' event to which the Shipping project
        // would listen and create a new shipment.
        //
        // In this showcase, I opted for the direct dependency, to keep the
        // examples more alike.
        public OrderController(IShippingController shippingController)
        {
            _shippingController = shippingController;
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
            _shippingController.Ship(order.Id);

            // alternatively, we could return the shipment id
            // but as this is the order slice, it feels more natural to return the order id
            // we can use it to retrieve more details about the order
            return order.Id;
        }
    }
}
