using Microsoft.AspNetCore.Mvc;
using System;

namespace _03_Shipping
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingController : IShippingController
    {
        private readonly IShippingService _shippingService;

        internal ShippingController(IShippingService shippingService)
        {
            this._shippingService = shippingService;
        }

        public Shipment Get(Guid orderId)
        {
            return this._shippingService.Get(orderId);
        }

        public Guid Ship(Guid orderId)
        {
            return this._shippingService.Ship(orderId);
        }
    }
}
