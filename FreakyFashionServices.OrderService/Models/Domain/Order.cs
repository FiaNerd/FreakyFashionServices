using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Order
    {
        public Order(int orderNumber, string customer, int quantity)
        {
            OrderNumber = orderNumber;
            Customer = customer;
            Quantity = quantity;
        }

        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
    }
}
