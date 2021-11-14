using Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> orders = new();

        public void Save(Order order)
        {
            this.orders.Add(order.Id, order);
        }
    }
}
