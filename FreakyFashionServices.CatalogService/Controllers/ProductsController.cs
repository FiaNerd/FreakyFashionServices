using FreakyFashionServices.CatalogService.Data;
using FreakyFashionServices.CatalogService.Models.Domain;
using FreakyFashionServices.CatalogService.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductServiceContext Context { get; }
        public ProductsController(ProductServiceContext context)
        {
            Context = context;
        }

        [HttpPost]
        public ActionResult CreateProduct(Product products)
        {
            var urlSlug = products.Name.Replace(" ", "").ToLower();

            Product product = new()
            {
                Name = products.Name,
                Description = products.Description,
                ImageUrl = products.ImageUrl,
                Price = products.Price,
                UrlSlug = urlSlug,
            };

            Context.Products.Add(product);

            Context.SaveChanges();

            return Created("", product);


        }
    }
}
