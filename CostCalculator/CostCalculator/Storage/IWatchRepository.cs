using CostCalculator.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostCalculator.Storage
{
    public interface IWatchRepository
    {
        Task<List<Watch>> GetWatches();
    }
}