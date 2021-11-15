using _02_Domain.Models;
using System;

namespace _02_Domain
{
    public interface IShippingRepository
    {
        void Create(Shipment shipment);
        Shipment Get(Guid orderId);
    }
}
