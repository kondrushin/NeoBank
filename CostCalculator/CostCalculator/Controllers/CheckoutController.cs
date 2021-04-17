using CostCalculator.Domain.Services;
using CostCalculator.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICartFactory _cartFactory;

        public CheckoutController(ICartFactory cartFactory)
        {
            _cartFactory = cartFactory;
        }

        [HttpPost]
        public async Task<ActionResult<WatchResponse>> Post(
            [FromBody] IEnumerable<string> watchRequest)
        {
            var cart = await _cartFactory.GetCart(watchRequest);
            var totalCost = cart.GetPrice();

            return new WatchResponse() { Price = totalCost };
        }
    }
}