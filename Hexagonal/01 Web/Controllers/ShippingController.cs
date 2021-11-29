using _02_Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace _01_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingController : ControllerBase
    {
        private readonly ILogger<ShippingController> _logger;
        private readonly IShippingService shippingService;

        public ShippingController(
            ILogger<ShippingController> logger,
            IShippingService shippingService)
        {
            _logger = logger;
            this.shippingService = shippingService;
        }

        [HttpPost]
        public Shipment Get(Order order)
        {
            var shipment = this.shippingService.GetShipment(new _02_Domain.Models.Order
            {
                Id = order.Id,
            });

            return new Shipment
            {
                Id = shipment.Id,
                OrderId = new Order
                {
                    Id = shipment.Order.Id,
                },
                Status = (ShippingStatus)shipment.Status,
            };
        }
    }
}
