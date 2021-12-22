using FreakyFashionServices.BasketService.Models.Domain;

namespace FreakyFashionServices.BasketService.Models.Dto
{
    public class BasketDto
    {
        public int OrderNumber { get; set; }

        public List<Items> Items { get; set; } = new List<Items>();
    }
}
