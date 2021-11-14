using Infrastructure.Models;
using System;

namespace Infrastructure
{
    public interface IShippingRepository
    {
        void Create(Shipment shipment);
        Shipment Get(Guid orderId);
    }
}
