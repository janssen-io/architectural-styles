using System;

namespace Web.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
