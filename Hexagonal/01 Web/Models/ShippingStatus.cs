using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public enum ShippingStatus
    {
        Unknown = 0,
        Requested,
        Pending,
        Moving,
        Delivered
    }
}
