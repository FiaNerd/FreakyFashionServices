namespace FreakyFashionServices.OrderService.Models.Dto
{
    public class Items
    {
        public Items(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
