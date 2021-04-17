namespace CostCalculator.Domain
{
    public class Watch
    {
        public Watch(
            string id,
            string name,
            int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Watch(
            string id, 
            string name, 
            int price, 
            Discount discount)
        {
            Id = id;
            Name = name;
            Price = price;
            Discount = discount;
        }

        public string Id { get; }
        public string Name { get; }
        public int Price { get; }
        public Discount Discount { get; }
    }
}