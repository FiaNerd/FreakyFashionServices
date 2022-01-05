using FreakyFashionServices.BasketService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace FreakyFashionServices.BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IDistributedCache Cache;
        public BasketsController(IDistributedCache cache)
        {
            Cache = cache;
        }

        [HttpPut("{ordernumber}")]
        public async Task<IActionResult> CreateReplaceBasket(BasketDto basket)
        {
            var serializedBasket = JsonSerializer.Serialize(basket);

                await Cache.SetStringAsync(basket.CustomerId.ToString(), serializedBasket);
          
            return NoContent();
        }


        [HttpGet("{customerId}")]
        public async Task<ActionResult<BasketDto>> GetBasket(int customerId)
        {
            var serializedBasket = await Cache.GetStringAsync(customerId.ToString());

            if (serializedBasket == null)
                return NotFound("This customerId dosn't exist!");

            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedBasket);

            return Ok(basketDto);
        }
    }
}
