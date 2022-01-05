using FreakyFashionServices.OrderService.Models.Domain;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FreakyFashionServices.OrderService.Models.Dto
{
    public class OrderLineDto
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
