namespace FreakyFashionServices.CatalogService.Models.Domain
{
    public class Product
    {
        public Product(string name, string description, string imageUrl, int price)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
