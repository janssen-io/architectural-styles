using Services.Models;

namespace Services
{
    public interface IShippingService
    {
        Shipment Ship(Order order);
        Shipment GetShipment(Order order);
    }
}
