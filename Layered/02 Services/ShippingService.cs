using Infrastructure;
using Services.Models;
using System;

namespace Services
{
    internal class ShippingService : IShippingService
    {
        private readonly IShippingRepository shippingRepo;

        public ShippingService(IShippingRepository shippingRepo)
        {
            this.shippingRepo = shippingRepo;
        }

        public Shipment GetShipment(Order order)
        {
            var shipment = this.shippingRepo.Get(order.Id);
            return new Shipment
            {
                Id = shipment.Id,
                OrderId = order,
                Status = (ShippingStatus)shipment.Status
            };
        }

        public Shipment Ship(Order order)
        {
            var shipment = new Infrastructure.Models.Shipment
            {
                Id = Guid.NewGuid(),
                OrderId = new Infrastructure.Models.Order
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice,
                },
                Status = Infrastructure.Models.ShippingStatus.Requested
            };

            this.shippingRepo.Create(shipment);

            return new Shipment
            {
                Id = shipment.Id,
                OrderId = order,
                Status = (ShippingStatus)shipment.Status
            };
        }
    }
}
