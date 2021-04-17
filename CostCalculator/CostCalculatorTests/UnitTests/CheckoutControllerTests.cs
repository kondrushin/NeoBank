using CostCalculator.Controllers;
using CostCalculator.Domain;
using CostCalculator.Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CostCalculatorTests
{
    public class CheckoutControllerTests
    {
        private readonly Mock<ICartFactory> cartFactoryMock;

        public CheckoutControllerTests()
        {
            cartFactoryMock = new Mock<ICartFactory>();
        }

        [Fact]
        public async Task GetPrice_OneWatch_ShouldCallGetCartAndReturnPrice()
        {
            var ids = new List<string> { "001" };

            var watch = new Watch("001", "Casio", 30);
            var watchForPurchase = new WatchForPurchase(watch, 1);
            var cart = new Cart(new List<WatchForPurchase> { watchForPurchase });

            var controller = new CheckoutController(cartFactoryMock.Object);
            cartFactoryMock
                .Setup(x => x.GetCart(ids))
                .Returns(Task.FromResult(cart));

            var response = await controller.Post(ids);

            cartFactoryMock.Verify(x => x.GetCart(ids), Times.Once());

            Assert.Equal(30, response.Value.Price);
        }
    }
}