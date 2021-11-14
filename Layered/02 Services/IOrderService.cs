using Services.Models;

namespace Services
{
    public interface IOrderService
    {
        Shipment PlaceOrder(Order order);
    }
}
