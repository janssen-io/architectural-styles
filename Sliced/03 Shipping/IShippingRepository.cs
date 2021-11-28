using System;

namespace _03_Shipping
{
	internal interface IShippingRepository
	{
		Guid Create(Shipment shipment);
		Shipment GetShipmentForOrder(Guid orderId);
	}
}