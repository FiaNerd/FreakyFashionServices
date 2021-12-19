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
                ArticleNumber = products.ArticleNumber,
                UrlSlug = urlSlug,
            };

            Context.Products.Add(product);

            Context.SaveChanges();

            return Created("", product);


        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            var productDto = Context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                ArticleNumber = p.ArticleNumber,
                UrlSlug= p.UrlSlug,
            });

            return productDto;
        }

        //public class UpdateProductDto
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }

        //    public string Description { get; set; }

        //    public string ImageUrl { get; set; }

        //    public int Price { get; set; }

        //    public string UrlSlug { get; set; }

        //}
    }
}
