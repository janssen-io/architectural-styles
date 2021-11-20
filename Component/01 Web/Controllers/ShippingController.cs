using _03_Shipping;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _01_Web
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingController
    {
        private readonly IShippingService shippingService;

        public ShippingController(IShippingService shippingService)
        {
            this.shippingService = shippingService;
        }

        public Shipment Get(Guid orderId)
        {
            return this.shippingService.Get(orderId);
        }
    }
}
