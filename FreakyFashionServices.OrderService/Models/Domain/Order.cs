using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Order
    {
        public Order(int customerId)
        {
            CustomerId = customerId;
        }

        public Order(int customerId, string customer)
        {
            CustomerId = customerId;
            Customer = customer;
        }


        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public IList<OrderLine> OrderLine { get; set; } = new List<OrderLine>();

    }
}
