using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Basket
    {
        public Basket(int orderNumber, int productId, int quantity)
        {
            OrderNumber = orderNumber;
            ProductId = productId;
            Quantity = quantity;
        }

        [Key]
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
