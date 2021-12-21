using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Basket
    {
        public Basket(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

        [Key]
        public int OrderNumber { get; set; }

        public List<Items> Items { get; set; }

    }
}
