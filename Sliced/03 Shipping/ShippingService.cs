using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shipping
{
    internal class ShippingService : IShippingService
    {
        private readonly IShippingRepository _repository;

        internal ShippingService(IShippingRepository repository)
        {
            _repository = repository;
        }
        
        public Shipment Get(Guid orderId)
        {
            return _repository.GetShipmentForOrder(orderId);
        }

        public Guid Ship(Guid orderId)
        {
            var shipment =  new Shipment
            {
                OrderId = orderId,
                Status = ShippingStatus.Requested,
            };

            return _repository.Create(shipment);
        }
    }
}
