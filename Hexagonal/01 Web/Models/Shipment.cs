using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Order OrderId { get; set; }
        public ShippingStatus Status { get; set; }
    }
}
