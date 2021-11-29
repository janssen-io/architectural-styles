using Infrastructure;
using Moq;
using Services.Models;
using System;
using Xunit;

using Infra = Infrastructure.Models;

namespace Services.Tests
{
    public class ShippingServiceTests
    {
        [Fact]
        public void ShippingAnOrder_CreatesShipmentWith_StatusRequested()
        {
            // Arrange
            var shippingRepo = new Mock<IShippingRepository>();
            var shippingService =
                ServicesFactory.CreateShippingService(shippingRepo.Object);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = 13.37m,
            };

            // Act
            shippingService.Ship(order);

            // Assert
            shippingRepo.Verify(repo => repo.Create(
                It.Is<Infra.Shipment>(s =>
                    s.Order.Id == order.Id 
                    && s.Status == Infra.ShippingStatus.Requested)));
        }
    }
}
