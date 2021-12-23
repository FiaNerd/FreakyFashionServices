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

                await Cache.SetStringAsync(basket.OrderNumber.ToString(), serializedBasket);
          
            return NoContent();
        }


        [HttpGet("{ordernumber}")]
        public async Task<ActionResult<BasketDto>> GetBasket(int orderNumber)
        {
            var serializedBasket = await Cache.GetStringAsync(orderNumber.ToString());

            if (serializedBasket == null)
                return NotFound("This ordernumber dosn't exist!");

            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedBasket);

            return Ok(basketDto);
        }
    }
}
