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
        public BasketsController(IDistributedCache cache)
        {
            Cache = cache;
        }

        public IDistributedCache Cache { get; }

        [HttpPut("{ordernumber}")]
        public async Task<IActionResult> CreateReplaceBasket(BasketDto basketDto)
        {
            var serializedBasket = JsonSerializer.Serialize(basketDto);

            await Cache.SetStringAsync(basketDto.OrderNumber.ToString(), serializedBasket);

            return NoContent();
        }


        [HttpGet("{ordernumber}")]
        public async Task<ActionResult<BasketDto>> GetBasket(int orderNumber)
        {
            var serializedBasket = await Cache.GetStringAsync(orderNumber.ToString());

            if (serializedBasket == null)
                return NotFound();

            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedBasket);

            return Ok(basketDto);
        }
    }
}
