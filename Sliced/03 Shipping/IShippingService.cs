using System;

namespace _03_Shipping
{
    internal interface IShippingService
    {
        Guid Ship(Guid orderId);
        Shipment Get(Guid orderId);
    }
}
