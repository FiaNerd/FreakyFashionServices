using FreakyFashionServices.CatalogService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.CatalogService.Data
{
    public class ProductServiceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductServiceContext(DbContextOptions<ProductServiceContext> options)
            : base(options)
        {
           
        }
    }
}
