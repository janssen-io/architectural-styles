using _02_Domain.Models;
using Moq;
using System;
using Xunit;

namespace _02_Domain.Tests
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
                DomainFactory.CreateShippingService(shippingRepo.Object);
            var orderService =
                DomainFactory.CreateOrderService(orderRepo.Object, shippingService);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = 13.37m,
            };

            // Act
            orderService.PlaceOrder(order);

            // Assert
            orderRepo.Verify(repo => repo.Save(
                It.Is<Order>(
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
                DomainFactory.CreateShippingService(shippingRepo.Object);
            var orderService =
                DomainFactory.CreateOrderService(orderRepo.Object, shippingService);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                TotalPrice = 13.37m,
            };

            // Act
            orderService.PlaceOrder(order);

            // Assert
            shippingRepo.Verify(repo => repo.Create(
                It.Is<Shipment>(s => s.Order.Id == order.Id)));
        }
    }
}
