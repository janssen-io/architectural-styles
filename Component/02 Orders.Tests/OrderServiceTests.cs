using _03_Shipping;
using Moq;
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
            var service = Factory.CreateOrderService(shipper.Object);

            // Act
            var id = service.PlaceOrder(13.37m);

            // Assert
            Assert.Equal(13.37m, service.Get(id).TotalPrice);
        }

        [Fact]
        public void PlacingAnOrder_ShipsIt()
        {
            // Arrange
            var shipper = new Mock<IShippingService>();
            var service = Factory.CreateOrderService(shipper.Object);

            // Act
            var id = service.PlaceOrder(13.37m);

            // Assert
            shipper.Verify(s => s.Ship(id));
        }
    }
}
