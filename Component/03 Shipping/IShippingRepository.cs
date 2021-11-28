using System;

namespace _03_Shipping
{
	internal interface IShippingRepository
	{
		Guid Ship(Shipment shipment);
		Shipment GetByOrderId(Guid orderId);
	}
}