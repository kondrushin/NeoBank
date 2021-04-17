using CostCalculator.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostCalculator.Storage
{
    public class WatchRepository : IWatchRepository
    {
        public async Task<List<Watch>> GetWatches()
        {
            return new List<Watch>()
            {
                new Watch("001", "Rolex", 100, new Discount(3, 200)),
                new Watch("002", "Michael Kors", 80, new Discount(2, 120)),
                new Watch("003", "Swatch", 50),
                new Watch("004", "Casio", 30)
            };
        }
    }
}