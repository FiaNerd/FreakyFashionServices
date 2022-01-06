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
            var basketDto = await FetchBasket(orderDto.CustomerId);

            var orderLines = basketDto.OrderLine.Select(x =>
                new OrderLineDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                });

            var newOrder = new Order(orderDto.CustomerId, orderDto.Customer);

            foreach (var item in orderLines)
            {
                var newOrderLineDto = new OrderLine
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,

                };

                newOrder.OrderLine.Add(newOrderLineDto);
            }

            bool customerExists = Context.Order.Any(x => x.CustomerId == orderDto.CustomerId);

            if (ModelState.IsValid && !customerExists)
            {

                Context.Order.Add(newOrder);

                await Context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("There is already a customer with this id, try another customer id");
            }

            return Created(" ", new { orderId = newOrder.OrderId });
        }

            private async Task<BasketDto> FetchBasket(int customerId)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8000/api/baskets/{customerId}")
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











