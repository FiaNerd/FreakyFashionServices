using FreakyFashionServices.OrderService.Data;
using FreakyFashionServices.OrderService.Models.Domain;
using FreakyFashionServices.OrderService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

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
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            var basketDto = await FetchBasket(orderDto.OrderNumber);

            var orderLines = basketDto.OrderLine.Select(x =>
                new OrderLineDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                });

            var newOrder = new Order(orderDto.OrderNumber, orderDto.Customer);

            foreach (var item in orderLines)
            {
                var newOrderLineDto = new OrderLine
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,

                };

                newOrder.OrderLine.Add(newOrderLineDto);
            }

            Context.Order.Add(newOrder);

            await Context.SaveChangesAsync();

            return Created("", new { orderid = newOrder.OrderId });
        }

            private async Task<BasketDto> FetchBasket(int ordernumber)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8000/api/baskets/{ordernumber}")
                {
                    Headers = { { HeaderNames.Accept, "application/json" }, }
                };

                var httpClient = httpClientFactory.CreateClient();

                using var response = await httpClient.SendAsync(request);

                var orderLines = Enumerable.Empty<OrderLineDto>();

                var serializedProduct = await response.Content.ReadAsStringAsync();

                var serializeOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedProduct);

                return basketDto;
            }
        }
    }











