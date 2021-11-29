using System;

namespace Infrastructure.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public ShippingStatus Status { get; set; }
    }
}
