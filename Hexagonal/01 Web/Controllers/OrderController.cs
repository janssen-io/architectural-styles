using _02_Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Web.Models;

namespace _01_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService orderService;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService)
        {
            _logger = logger;
            this.orderService = orderService;
        }

        [HttpPost]
        public Shipment PlaceOrder(Order order)
        {
            var shipment = this.orderService.PlaceOrder(new _02_Domain.Models.Order
            {
                // Ignore the Id on the request, as we cannot be certain it's valid.
                Id = Guid.NewGuid(), 
                TotalPrice = order.TotalPrice,
            });

            _logger.LogInformation("Order placed");

            return new Shipment
            {
                Id = shipment.Id,
                OrderId = new Order
                {
                    Id = shipment.OrderId.Id,
                    TotalPrice = shipment.OrderId.TotalPrice,
                },
                Status = (ShippingStatus)shipment.Status,
            };
        }
    }
}
