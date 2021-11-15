using _02_Domain.Models;

namespace _02_Domain
{
    public interface IOrderService
    {
        Shipment PlaceOrder(Order order);
    }
}
