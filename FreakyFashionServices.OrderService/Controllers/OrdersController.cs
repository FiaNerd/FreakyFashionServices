using FreakyFashionServices.OrderService.Data;
using FreakyFashionServices.OrderService.Models.Domain;
using FreakyFashionServices.OrderService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FreakyFashionServices.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderServiceContext Context { get; }

        private readonly IHttpClientFactory httpClientFactory;

        public OrdersController(IHttpClientFactory httpClientFactory, OrderServiceContext context)
        {
            this.httpClientFactory = httpClientFactory;
            Context = context;
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrders(OrderDto order)
        {
            // GET api/catalog
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8000/api/baskets/" + order.OrderNumber);

            request.Headers.Add("Accept", "application/json");

            var client = httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedProduct = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var basket = JsonSerializer.Deserialize<BasketDto>(serializedProduct, serializeOptions);

            var newOrder = new Order(order.OrderNumber, order.Customer);
   
            foreach (var item in basket.Items)
            {
                newOrder.OrderLine += $"{item.ProductId} qty({item.Quantity}) , ";
;            }

            Context.Order.Add(newOrder);
            await Context.SaveChangesAsync();

            return Created("", $"orderId: {newOrder.OrderId}");
        }
    }
}





