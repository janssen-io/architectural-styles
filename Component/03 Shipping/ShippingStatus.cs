using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shipping
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
