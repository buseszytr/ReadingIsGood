using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ReadingIsGood.API.Resources;
using ReadingIsGood.Domain.Models;
using ReadingIsGood.Domain.ResponseModels;
using ReadingIsGood.Domain.Services;

namespace ReadingIsGood.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderResource orderResource)
        {
            Order order = mapper.Map<OrderResource, Order>(orderResource);

            OrderResponse orderResponse = await orderService.CreateOrder(order);

            if (orderResponse.Success)
            {
                return Ok(orderResponse.order);
            }

            return BadRequest(orderResponse.Message);
        }

        [HttpGet("{customerId:Guid}")]
        public async Task<IActionResult> GetOrder(Guid customerId)
        {
            CustomerOrderListResponse customerOrder = await orderService.GetOrder(customerId);

            if (customerOrder.Success)
            {
                return Ok(customerOrder.orderList);
            }

            return BadRequest(customerOrder.Message);
        }

        [HttpGet]
        public IActionResult GetOrderDetail(Guid orderId, OrderStatus status)
        {
            var orderResponse = orderService.UpdateOrderStatus(orderId, status);

            if (orderResponse.Success)
            {
                return Ok(orderResponse.order);
            }

            return BadRequest(orderResponse.Message);
        }
    }
}
