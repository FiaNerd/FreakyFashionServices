using FreakyFashionServices.CatalogService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.CatalogService.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
           
        }
    }
}
