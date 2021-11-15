using _02_Domain.Models;
using System;

namespace _02_Domain
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
            return shipment;
        }

        public Shipment Ship(Order order)
        {
            var shipment = new Shipment
            {
                Id = Guid.NewGuid(),
                OrderId = order,
                Status = ShippingStatus.Requested
            };

            this.shippingRepo.Create(shipment);

            return shipment;
        }
    }
}
