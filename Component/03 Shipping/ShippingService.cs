using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shipping
{
    internal class ShippingService : IShippingService
    {
        private readonly IShippingRepository _shippingRepository;

        public ShippingService(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }
        
        public Shipment Get(Guid orderId)
        {
            return _shippingRepository.GetByOrderId(orderId);
        }

        public Guid Ship(Guid orderId)
        {
            var shipment =  new Shipment
            {
                OrderId = orderId,
                Status = ShippingStatus.Requested,
            };

            return _shippingRepository.Ship(shipment);
        }
    }
}
