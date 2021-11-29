using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> _orders = new();

        public void Save(Order order)
        {
            _orders.Add(order.Id, order);
        }
    }
}
