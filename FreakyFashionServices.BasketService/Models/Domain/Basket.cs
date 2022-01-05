using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Basket
    {
        public Basket(int customerId)
        {
            CustomerId = customerId;
        }

        [Key]
        public int CustomerId { get; set; }

        public List<Items> Items { get; set; }

    }
}
