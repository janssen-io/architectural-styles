using System;
using System.Collections.Generic;

namespace _03_Shipping
{
	internal class ShippingRepository : IShippingRepository
	{
        private readonly Dictionary<Guid, Shipment> shipments = new();

		internal ShippingRepository(ILiteDatabase db)
		{
			_db = db;
		}
        
        public Guid Create(Shipment shipment)
        {
	        shipment.Id = Guid.NewGuid();
            this.shipments[shipment.OrderId] = shipment;
            return shipment.Id;
        }

        public Shipment GetShipmentForOrder(Guid orderId)
        {
	        return shipments[orderId];
        }
	}
}