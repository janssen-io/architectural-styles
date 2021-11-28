using System;
using Xunit;

namespace _03_Shipping.Tests.cs
{
    public class ShippingServiceTests
    {
        [Fact]
        public void ShippingAProduct_CreatesAShipment()
        {
            // Arrange
            var service = Factory.CreateController();
            var orderId = Guid.NewGuid();

            // Act
            var _ = service.Ship(orderId);

            // Assert
            var shipment = service.Get(orderId);
            Assert.Equal(ShippingStatus.Requested, shipment.Status);
            Assert.Equal(orderId, shipment.OrderId);
        }
    }
}
