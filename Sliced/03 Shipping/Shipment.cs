using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shipping
{
    // You could opt to make the domain models internal.
    // The controller should then expose its own models.
    public class Shipment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public ShippingStatus Status { get; set; }
    }
}
