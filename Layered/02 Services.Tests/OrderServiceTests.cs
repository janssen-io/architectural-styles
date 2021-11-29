using Infrastructure;
using Moq;
using Services.Models;
using System;
using Xunit;

using Infra = Infrastructure.Models;

namespace Services.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlacingAnOrder_PersistsTheOrder()
        {
            // Arrange
            var orderRepo = new Mock<IOrderRepository>();
            var shippingRepo = new Mock<IShippingRepository>();
            var shippingService =
                ServicesFactory.CreateShippingService(shippingRepo.Object);
            var orderService =
                ServicesFactory.CreateOrderService(orderRepo.Object, shippingService);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = 13.37m,
            };

            // Act
            orderService.PlaceOrder(order);

            // Assert
            orderRepo.Verify(repo => repo.Save(
                It.Is<Infra.Order>(
                    o => o.Id == order.Id
                    && o.TotalPrice == order.TotalPrice)));
        }

        [Fact]
        public void PlacingAnOrder_CreatesShipmentForOrder()
        {
            // Arrange
            var orderRepo = new Mock<IOrderRepository>();
            var shippingRepo = new Mock<IShippingRepository>();
            var shippingService =
                ServicesFactory.CreateShippingService(shippingRepo.Object);
            var orderService =
                ServicesFactory.CreateOrderService(orderRepo.Object, shippingService);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = 13.37m,
            };

            // Act
            orderService.PlaceOrder(order);

            // Assert
            shippingRepo.Verify(repo => repo.Create(
                It.Is<Infra.Shipment>(s => s.Order.Id == order.Id)));
        }
    }
}
