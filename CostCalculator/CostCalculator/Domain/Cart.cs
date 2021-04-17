using System.Collections.Generic;
using System.Linq;

namespace CostCalculator.Domain
{
    public class Cart
    {
        public Cart(List<WatchForPurchase> items)
        {
            Items = items;
        }

        public List<WatchForPurchase> Items { get; set; }

        public int GetPrice()
        {
            return Items.Sum(item => item.GetPrice());
        }
    }
}