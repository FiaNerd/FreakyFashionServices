using System.ComponentModel.DataAnnotations;

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

        [Key]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
