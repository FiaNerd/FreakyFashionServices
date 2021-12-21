using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Order
    {
        public Order(int orderNumber, string customer)
        {
            OrderNumber = orderNumber;
            Customer = customer;
        }

        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string Customer { get; set; }
    }
}
