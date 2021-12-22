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
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            new HttpRequestMessage(HttpMethod.Get, "http://localhost:8000/api/basket/" + orderDto.OrderNumber);

            Order order = new Order(
                    orderNumber: orderDto.OrderNumber,
                    customer: orderDto.Customer,
                    quantity: orderDto.Quantity
                   );

            Context.Order.Add(order);

            await Context.SaveChangesAsync();

            return Created(" ", order.OrderId);
        }



        //[HttpPost]
        //public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        //{
          

            //var httpRequestMessage = new HttpRequestMessage(
            //    HttpMethod.Get,
            //     "http://localhost:8000/api/basket/" + orderDto.OrderNumber)
            //{
            //    Headers =
            //{
            //    { HeaderNames.Accept, "application/json" }
            //}
            //};

            //Order order = new Order(
            //           orderNumber: orderDto.OrderNumber,
            //           customer: orderDto.Customer,
            //            quantity: orderDto.Quantity
            //          );

            //var httpClient = httpClientFactory.CreateClient();
            //var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            //if (httpResponseMessage.IsSuccessStatusCode)
            //{
            //    using var contentStream =
            //        await httpResponseMessage.Content.ReadAsStreamAsync();

            //}

            //Context.Order.Add(order);

            //await Context.SaveChangesAsync();


            //return Created("", order.OrderId);
        }
    }




    //[HttpPost]
    //public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
    //{
    //    new HttpRequestMessage(HttpMethod.Get, "http://localhost:8000/api/basket/" + orderDto.OrderNumber);

    //    Order order = new Order(
    //         orderNumber: orderDto.OrderNumber,
    //         customer: orderDto.Customer,
    //          quantity: orderDto.Quantity
    //        ); 

    //    Context.Order.Add(order);

    //    await Context.SaveChangesAsync();

    //    return Created(" ", order.OrderId);
    //}

//}


//var httpRequestMessage = new HttpRequestMessage(
//  HttpMethod.Get,
//  "http://localhost:8000/api/basket/" + orderDto.OrderNumber)
//{
//    Headers =
//{
//    { HeaderNames.Accept, "application/json" },
//    //{ HeaderNames.UserAgent, "HttpRequestsSample" }
//}
//};

//var httpClient = _httpClientFactory.CreateClient();
//var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

//if (httpResponseMessage.IsSuccessStatusCode)
//{
//    using var contentStream =
//        await httpResponseMessage.Content.ReadAsStreamAsync();

//    Order order = new Order(
//             orderNumber: orderDto.OrderNumber,
//             customer: orderDto.Customer,
//quantity: orderDto.Quantity
//            );
//}