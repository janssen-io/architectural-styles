using System;

namespace _02_Orders
{
    public interface IOrderService
    {
        public Order Get(Guid orderId);
        public Guid PlaceOrder(decimal totalPrice);
    }
}
