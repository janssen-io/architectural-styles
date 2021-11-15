using _02_Domain;
using _02_Domain.Models;
using System;
using System.Collections.Generic;

namespace _03_Infrastructure
{
    internal class ShippingRepository : IShippingRepository
    {
        // Stores shipments by order id
        private readonly Dictionary<Guid, Shipment> shipments = new();

        public void Create(Shipment shipment)
        {
            this.shipments[shipment.OrderId.Id] = shipment;
        }

        public Shipment Get(Guid orderId)
        {
            return this.shipments[orderId];
        }
    }
}
