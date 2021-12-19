using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Basket
    {
        public Basket(int customerNumber, string productName, int price, int quantity)
        {
            CustomerNumber = customerNumber;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        [Key]
        public int CustomerNumber { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
