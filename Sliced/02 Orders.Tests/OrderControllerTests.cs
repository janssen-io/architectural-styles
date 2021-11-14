using _03_Shipping;
using Moq;
using System;
using Xunit;

namespace _02_Orders.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void PlacingAnOrder_StoresTheOrder()
        {
            // Arrange
            var shipper = new Mock<IShippingService>();
            var controller = new OrderController(shipper.Object);

            // Act
            var id = controller.PlaceOrder(13.37m);

            // Assert
            Assert.Equal(13.37m, controller.Get(id).TotalPrice);
        }

        [Fact]
        public void PlacingAnOrder_ShipsIt()
        {
            // Arrange
            var shipper = new Mock<IShippingService>();
            var controller = new OrderController(shipper.Object);

            // Act
            var id = controller.PlaceOrder(13.37m);

            // Assert
            shipper.Verify(s => s.Ship(id));
        }
    }
}
