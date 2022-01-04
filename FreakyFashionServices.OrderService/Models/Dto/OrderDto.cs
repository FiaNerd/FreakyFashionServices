namespace FreakyFashionServices.OrderService.Models.Dto
{
    public class OrderDto
    {
        // ska bara innehålla de fält som behövs för att mappa inkommande data
        public int Idnetifier { get; set; }
        public int OrderNumber { get; set; }
        public string Customer { get; set; }
        public IEnumerable<OrderLineDto> OrderLine { get; set; } = new List<OrderLineDto>();

    }
}
