using Infrastructure.Models;
using System;

namespace Infrastructure
{
    public interface IShippingRepository
    {
        Guid Create(Shipment shipment);
        Shipment GetShipmentForOrder(Guid orderId);
    }
}
