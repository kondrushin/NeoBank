using Newtonsoft.Json;

namespace CostCalculator.Interface
{
    public class WatchResponse
    {
        [JsonProperty("price")]
        public int Price { get; set; }
    }
}