﻿using System;

namespace _02_Domain.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Order OrderId { get; set; }
        public ShippingStatus Status { get; set; }
    }
}
