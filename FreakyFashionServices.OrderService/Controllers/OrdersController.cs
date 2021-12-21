using FreakyFashionServices.OrderService.Data;
using FreakyFashionServices.OrderService.Models.Domain;
using FreakyFashionServices.OrderService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace FreakyFashionServices.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private OrderServiceContext Context { get; }
        public OrdersController(IHttpClientFactory httpClientFactory, OrderServiceContext context)
        {
            this.httpClientFactory = httpClientFactory;
            Context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            new HttpRequestMessage(HttpMethod.Get, "http://localhost:6379/api/basket/" + orderDto.OrderNumber);

            Order order = new Order(
                 orderNumber: orderDto.OrderNumber,
                 customer: orderDto.Customer
                );

            Context.Order.Add(order);

            await Context.SaveChangesAsync();

            return Created(" ", order.OrderId);
        }


    }
}
