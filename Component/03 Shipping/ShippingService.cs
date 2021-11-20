using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shipping
{
    internal class ShippingService : IShippingService
    {
        private readonly Dictionary<Guid, Shipment> shipments = new();

        public Shipment Get(Guid orderId)
        {
            return this.shipments[orderId];
        }

        public Guid Ship(Guid orderId)
        {
            var shipment =  new Shipment
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                Status = ShippingStatus.Requested,
            };

            this.shipments[orderId] = shipment;

            return shipment.Id;
        }
    }
}
