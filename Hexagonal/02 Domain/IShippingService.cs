using _02_Domain.Models;

namespace _02_Domain
{
    public interface IShippingService
    {
        Shipment Ship(Order order);
        Shipment GetShipment(Order order);
    }
}
