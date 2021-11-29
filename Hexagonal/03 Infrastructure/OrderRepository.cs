using _02_Domain;
using _02_Domain.Models;
using System;
using System.Collections.Generic;

namespace _03_Infrastructure
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
