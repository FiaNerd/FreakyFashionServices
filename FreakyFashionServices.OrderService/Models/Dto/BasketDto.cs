using FreakyFashionServices.OrderService.Models.Domain;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FreakyFashionServices.OrderService.Models.Dto
{
    public class BasketDto
    {
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("items")]
        public IList<OrderLineDto> OrderLine { get; set; } = new List<OrderLineDto>();
    }
}
