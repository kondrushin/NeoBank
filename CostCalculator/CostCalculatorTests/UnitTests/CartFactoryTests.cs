using CostCalculator.Domain;
using CostCalculator.Domain.Services;
using CostCalculator.Storage;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CostCalculatorTests
{
    public class CartFactoryTests
    {
        private readonly Mock<IWatchRepository> watchRepositoryMock;
        private readonly CartFactory factory;

        public CartFactoryTests()
        {
            watchRepositoryMock = new Mock<IWatchRepository>();
            factory = new CartFactory(watchRepositoryMock.Object);
        }

        [Fact]
        public async Task GetCart_OneWatch_InRepo_ShouldBuildCart()
        {
            var watch = new Watch("004", "Casio", 30);

            watchRepositoryMock
                .Setup(x => x.GetWatches())
                .Returns(Task.FromResult(new List<Watch>() { watch }));

            var cart = await factory.GetCart(new List<string> { "004" });

            Assert.Single(cart.Items);
            Assert.Equal(watch, cart.Items[0].Watch);
            Assert.Equal(1, cart.Items[0].Count);
        }

        [Fact]
        public async Task GetCart_TwoWatches_InRepo_ShouldBuildCart()
        {
            var watch = new Watch("004", "Casio", 30);

            watchRepositoryMock
                .Setup(x => x.GetWatches())
                .Returns(Task.FromResult(new List<Watch>() { watch }));

            var cart = await factory.GetCart(new List<string> { "004", "004" });

            Assert.Single(cart.Items);
            Assert.Equal(watch, cart.Items[0].Watch);
            Assert.Equal(2, cart.Items[0].Count);
        }

        [Fact]
        public async Task GetCart__NotInRepo_ShouldSkip()
        {
            var watch = new Watch("004", "Casio", 30);

            watchRepositoryMock
                .Setup(x => x.GetWatches())
                .Returns(Task.FromResult(new List<Watch>() { watch }));

            var cart = await factory.GetCart(new List<string> { "005" });

            Assert.Empty(cart.Items);
        }

        [Fact]
        public async Task GetCart_TwoDifferentWatches_InRepo_ShouldBuildCart()
        {
            var watch1 = new Watch("004", "Casio", 30);
            var watch2 = new Watch("005", "Casio+", 40);

            watchRepositoryMock
                .Setup(x => x.GetWatches())
                .Returns(Task.FromResult(new List<Watch>() { watch1, watch2 }));

            var cart = await factory.GetCart(new List<string> { "004", "005" });

            Assert.Equal(2, cart.Items.Count);

            Assert.Equal(watch1, cart.Items[0].Watch);
            Assert.Equal(1, cart.Items[0].Count);

            Assert.Equal(watch2, cart.Items[1].Watch);
            Assert.Equal(1, cart.Items[1].Count);
        }

        [Fact]
        public async Task GetCart_WatchesNotInOrder_InRepo_ShouldBuildCart()
        {
            var watch1 = new Watch("004", "Casio", 30);
            var watch2 = new Watch("005", "Casio+", 40);

            watchRepositoryMock
                .Setup(x => x.GetWatches())
                .Returns(Task.FromResult(new List<Watch>() { watch1, watch2 }));

            var cart = await factory.GetCart(new List<string> { "004", "005", "004" });

            Assert.Equal(2, cart.Items.Count);

            Assert.Equal(watch1, cart.Items[0].Watch);
            Assert.Equal(2, cart.Items[0].Count);

            Assert.Equal(watch2, cart.Items[1].Watch);
            Assert.Equal(1, cart.Items[1].Count);
        }
    }
}