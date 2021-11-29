using _02_Domain.Models;
using System;

namespace _02_Domain
{
    public interface IShippingRepository
    {
        Guid Create(Shipment shipment);
        Shipment GetShipmentForOrder(Guid orderId);
    }
}
