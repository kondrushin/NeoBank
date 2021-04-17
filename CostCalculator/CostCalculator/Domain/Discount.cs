namespace CostCalculator.Domain
{
    public class Discount
    {
        public Discount(int numberOfItems, int price)
        {
            NumberOfItems = numberOfItems;
            Price = price;
        }

        public int NumberOfItems { get; }

        public int Price { get; }
    }
}