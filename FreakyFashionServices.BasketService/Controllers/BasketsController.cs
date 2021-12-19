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

        [HttpPut("{customernumber}")]
        public async Task<IActionResult> CreateReplaceBasket(int customerNumber, BasketDto basketDto)
        {

            var serializedBasket = JsonSerializer.Serialize(basketDto);

            await Cache.SetStringAsync(basketDto.CustomerNumber.ToString(), serializedBasket);

            //if (customerNumber != basketDto.CustomerNumber)
            //    return BadRequest();

            //var existingCustomer = BasketDto.Get(customerNumber);

            //if (existingCustomer == null)
            //    return NotFound();

            //basketDto.Update(customerNumber);


            //var stockLevel = Context.Basket
            //   .FirstOrDefault(x => x.ArticleNumber == basketDto.ArticleNumber);

            //if (stockLevel == null)
            //{
            //    // Alternativt, använd AutoMapper
            //    stockLevel = new StockLevel(
            //        basketDto.ArticleNumber,
            //        basketDto.StockLevel
            //    );

            //    Context.StockLevel.Add(stockLevel);
            //}
            //else
            //{
            //    stockLevel.Stock = basketDto.StockLevel;
            //}

            //Context.SaveChanges();

            return NoContent();
        }
    }
}
