using FreakyFashionServices.OrderService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.OrderService.Data
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }

        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
