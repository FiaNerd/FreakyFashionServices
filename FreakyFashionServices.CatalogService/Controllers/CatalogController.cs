using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        [HttpPost("{name}")]
        public IActionResult CreateProducts(string name, ProductDto productDto)
        {
            return Ok();
        }
    }
}
