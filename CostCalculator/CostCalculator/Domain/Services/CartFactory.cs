using CostCalculator.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostCalculator.Domain.Services
{
    public class CartFactory : ICartFactory
    {
        private readonly IWatchRepository _watchRepository;

        public CartFactory(IWatchRepository watchRepository)
        {
            _watchRepository = watchRepository;
        }

        public async Task<Cart> GetCart(IEnumerable<string> watchIds)
        {
            var watches = await _watchRepository.GetWatches();

            var uniqueWatches = new Dictionary<string, int>();

            foreach (var watchId in watchIds)
            {
                if (uniqueWatches.ContainsKey(watchId))
                {
                    uniqueWatches[watchId] = uniqueWatches[watchId] + 1;
                }
                else
                {
                    if (watches.FirstOrDefault(x => x.Id == watchId) != null)
                    {
                        uniqueWatches.Add(watchId, 1);
                    }
                }
            }

            var itemsForPurchase = uniqueWatches
                .Keys
                .Select(watchId => new WatchForPurchase(watches
                    .FirstOrDefault(watch => watch.Id == watchId), uniqueWatches[watchId]))
                .Where(item => item.Watch != null)
                .ToList();

            return new Cart(itemsForPurchase);
        }
    }
}
