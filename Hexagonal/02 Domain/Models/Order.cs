using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
