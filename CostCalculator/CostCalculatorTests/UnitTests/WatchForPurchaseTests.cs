using CostCalculator.Domain;
using Xunit;

namespace CostCalculatorTests
{
    public class WatchForPurchaseTests
    {
        [Fact]
        public void GetPrice_NoDiscount_OneItem_ShouldReturnItemPrice()
        {
            var watch = new Watch("004", "Casio", 30);

            var watchForPurchase = new WatchForPurchase(watch, 1);

            Assert.Equal(30, watchForPurchase.GetPrice());
        }

        [Fact]
        public void GetPrice_NoDiscount_ThreeItems_ShouldReturnSum()
        {
            var watch = new Watch("004", "Casio", 30);

            var watchForPurchase = new WatchForPurchase(watch, 3);

            Assert.Equal(90, watchForPurchase.GetPrice());
        }

        [Fact]
        public void GetPrice_DiscountNotApplicable_ShouldReturnPrice()
        {
            var watch = new Watch("001", "Rolex", 100, new Discount(3, 200));
            var watchForPurchase = new WatchForPurchase(watch, 1);

            Assert.Equal(100, watchForPurchase.GetPrice());
        }

        [Fact]
        public void GetPrice_DiscountNotApplicable_ShouldReturnSum()
        {
            var watch = new Watch("001", "Rolex", 100, new Discount(3, 200));
            var watchForPurchase = new WatchForPurchase(watch, 2);

            Assert.Equal(200, watchForPurchase.GetPrice());
        }

        [Fact]
        public void GetPrice_DiscountISApplicable_ShouldReturnCost()
        {
            var watch = new Watch("001", "Rolex", 100, new Discount(3, 200));
            var watchForPurchase = new WatchForPurchase(watch, 3);

            Assert.Equal(200, watchForPurchase.GetPrice());
        }

        [Fact]
        public void GetPrice_DiscountIsApplicableTwice_ShouldReturnCost()
        {
            var watch = new Watch("001", "Rolex", 100, new Discount(3, 200));
            var watchForPurchase = new WatchForPurchase(watch, 2);

            Assert.Equal(200, watchForPurchase.GetPrice());
        }

        [Fact]
        public void GetPrice_DiscountIsApplicablePlusOne_ShouldReturnCost()
        {
            var watch = new Watch("001", "Rolex", 100, new Discount(3, 200));
            var watchForPurchase = new WatchForPurchase(watch, 4);

            Assert.Equal(300, watchForPurchase.GetPrice());
        }
    }
}
