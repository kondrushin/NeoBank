namespace CostCalculator.Domain
{
    public class WatchForPurchase
    {
        public WatchForPurchase(Watch watch, int count)
        {
            Watch = watch;
            Count = count;
        }

        public Watch Watch { get; }

        public int Count { get; set; }

        public int GetPrice()
        {
            if (IsDiscountApplicable())
            {
                return GetNonDiscountPrice();
            }
            else
            {
                return GetDiscountPrice();
            }
        }

        private int GetNonDiscountPrice()
        {
            return Watch.Price * Count;
        }

        private int GetDiscountPrice()
        {
            int numberOfItemsWithoutDiscount = Count % Watch.Discount.NumberOfItems;
            int numberOfItemsUnderDiscount = Count / Watch.Discount.NumberOfItems;
            return numberOfItemsWithoutDiscount * Watch.Price + numberOfItemsUnderDiscount * Watch.Discount.Price;
        }

        private bool IsDiscountApplicable()
        {
            return Watch.Discount == null || Count < Watch.Discount.NumberOfItems;
        }
    }
}