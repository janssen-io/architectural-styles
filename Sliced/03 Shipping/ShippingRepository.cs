using System;
using LiteDB;

namespace _03_Shipping
{
	internal class ShippingRepository : IShippingRepository
	{
		private readonly ILiteDatabase _db;

		internal ShippingRepository(ILiteDatabase db)
		{
			_db = db;
		}
        
        public Guid Create(Shipment shipment)
        {
	        shipment.Id = Guid.NewGuid();
	        var shipments = _db.GetCollection<Shipment>();
	        shipments.Insert(shipment);
            return shipment.Id;
        }

        public Shipment GetShipmentForOrder(Guid orderId)
        {
	        var shipments = _db.GetCollection<Shipment>();
	        return shipments.FindOne(shipment => shipment.OrderId == orderId);
        }
	}
}