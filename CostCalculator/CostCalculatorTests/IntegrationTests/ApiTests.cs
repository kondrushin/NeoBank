using CostCalculator;
using CostCalculator.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace CostCalculatorTests
{
    public class ApiTests
    {
        private readonly HttpClient _client;

        public ApiTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Post_OneWatch_GetPrice()
        {
            var req = new List<string> { "001" };

            var json = JsonConvert.SerializeObject(req);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var postRes = await _client.PostAsync("/api/checkout", stringContent);

            postRes.EnsureSuccessStatusCode();

            var resBody = await postRes.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<WatchResponse>(resBody);
            Assert.Equal(100, response.Price);
        }

        [Fact]
        public async Task Post_SeveralWatches_GetPrice()
        {
            var req = new List<string> { "001", "002", "001", "004", "003" };

            var json = JsonConvert.SerializeObject(req);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var postRes = await _client.PostAsync("/api/checkout", stringContent);

            postRes.EnsureSuccessStatusCode();

            var resBody = await postRes.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<WatchResponse>(resBody);
            Assert.Equal(360, response.Price);
        }

        [Fact]
        public async Task Post_OneWatchDoesNotExist_ShouldIgnoreWatchWhichDoesNotExist()
        {
            var req = new List<string> { "001", "002", "001", "004", "003", "009" };

            var json = JsonConvert.SerializeObject(req);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var postRes = await _client.PostAsync("/api/checkout", stringContent);

            postRes.EnsureSuccessStatusCode();

            var resBody = await postRes.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<WatchResponse>(resBody);
            Assert.Equal(360, response.Price);
        }

        [Fact]
        public async Task Post_EmptyPrice_ShouldReturnZeroPrice()
        {
            var req = new List<string>();

            var json = JsonConvert.SerializeObject(req);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var postRes = await _client.PostAsync("/api/checkout", stringContent);

            postRes.EnsureSuccessStatusCode();

            var resBody = await postRes.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<WatchResponse>(resBody);
            Assert.Equal(0, response.Price);
        }
    }
}