using CostCalculator.Domain;
using CostCalculator.Domain.Services;
using CostCalculator.Storage;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CostCalculatorTests
{
    public class CartTests
    {
        private readonly Mock<IWatchRepository> watchRepositoryMock;
        private readonly CartFactory factory;

        public CartTests()
        {
            watchRepositoryMock = new Mock<IWatchRepository>();
            factory = new CartFactory(watchRepositoryMock.Object);
        }

        [Fact]
        public void GetPrice_OneWatch_GetSum()
        {
            var watch = new Watch("004", "Casio", 30);
            var watchForPurchase = new WatchForPurchase(watch, 1);

            var cart = new Cart(new List<WatchForPurchase> { watchForPurchase });

            Assert.Equal(30, cart.GetPrice());
        }

        [Fact]
        public void GetPrice_TwoSameWatches_GetSum()
        {
            var watch = new Watch("004", "Casio", 30);
            var watchForPurchase = new WatchForPurchase(watch, 2);

            var cart = new Cart(new List<WatchForPurchase> { watchForPurchase });

            Assert.Equal(60, cart.GetPrice());
        }

        [Fact]
        public void GetPrice_ThreeWatches_GetSum()
        {
            var watch1 = new Watch("004", "Casio", 30);
            var watchForPurchase1 = new WatchForPurchase(watch1, 1);

            var watch2 = new Watch("005", "Casio", 40);
            var watchForPurchase2 = new WatchForPurchase(watch2, 1);

            var watch3 = new Watch("006", "Casio", 30);
            var watchForPurchase3 = new WatchForPurchase(watch3, 1);

            var cart = new Cart(new List<WatchForPurchase>
            {
                watchForPurchase1,
                watchForPurchase2,
                watchForPurchase3
            });

            Assert.Equal(100, cart.GetPrice());
        }
    }
}