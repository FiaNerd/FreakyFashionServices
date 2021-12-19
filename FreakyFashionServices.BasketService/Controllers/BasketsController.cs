using FreakyFashionServices.BasketService.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        //public BasketsController(IDistributedCache cache)
        //{
        //    Cache = cache;
        //}

        //public IDistributedCache? Cache { get; }

        [HttpPut]
        public IActionResult CreateReplaceBasket(BasketDto basketDto)
        {
            return NoContent();
        }
    }
}
