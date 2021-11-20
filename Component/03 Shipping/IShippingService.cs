using System;

namespace _03_Shipping
{
    public interface IShippingService
    {
        Guid Ship(Guid orderId);
        Shipment Get(Guid orderId);
    }
}
