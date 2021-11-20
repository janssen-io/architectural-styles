using System;
using _02_Orders;
using Microsoft.AspNetCore.Mvc;

namespace _01_Web
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public Order Get(Guid orderId)
        {
            return this.orderService.Get(orderId);
        }

        public Guid PlaceOrder(decimal totalPrice)
        {
            return this.orderService.PlaceOrder(totalPrice);
        }
    }
}
