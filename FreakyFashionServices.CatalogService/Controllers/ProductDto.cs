namespace FreakyFashionServices.CatalogService.Controllers
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string UrlSlug { get; set; }
    }
}