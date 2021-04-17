using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostCalculator.Domain.Services
{
    public interface ICartFactory
    {
        Task<Cart> GetCart(IEnumerable<string> watchIds);
    }
}