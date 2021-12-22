namespace FreakyFashionServices.OrderService.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
    }
}
