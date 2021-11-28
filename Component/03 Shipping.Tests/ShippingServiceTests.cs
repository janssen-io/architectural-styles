using System;
using Xunit;

namespace _03_Shipping.Tests
{
    public class ShippingServiceTests
    {
        [Fact]
        public void ShippingAProduct_CreatesAShipment()
        {
            // Arrange
            var service = Factory.CreateShippingService(":memory:");
            var orderId = Guid.NewGuid();

            // Act
            service.Ship(orderId);

            // Assert
            var shipment = service.Get(orderId);
            Assert.Equal(ShippingStatus.Requested, shipment.Status);
            Assert.Equal(orderId, shipment.OrderId);
        }
    }
}
