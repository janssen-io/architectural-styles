using _02_Domain.Models;
using Moq;
using System;
using Xunit;

namespace _02_Domain.Tests
{
    public class ShippingServiceTests
    {
        [Fact]
        public void ShippingAnOrder_CreatesShipmentWith_StatusRequested()
        {
            // Arrange
            var shippingRepo = new Mock<IShippingRepository>();
            var shippingService =
                DomainFactory.CreateShippingService(shippingRepo.Object);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = 13.37m,
            };

            // Act
            shippingService.Ship(order);

            // Assert
            shippingRepo.Verify(repo => repo.Create(
                It.Is<Shipment>(s =>
                    s.OrderId.Id == order.Id 
                    && s.Status == ShippingStatus.Requested)));
        }
    }
}
