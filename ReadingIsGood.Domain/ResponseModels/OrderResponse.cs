using System;
using ReadingIsGood.Domain.Models;

namespace ReadingIsGood.Domain.ResponseModels
{
    public class OrderResponse : BaseResponse
    {
        public Order order { get; set; }
        public OrderResponse(bool success, string message, Order order) : base(success, message)
        {
            this.order = order;
        }
        public OrderResponse(Order order) : this(true, String.Empty, order) { }
        public OrderResponse(string message) : this(false, message, null) { }
    }
}
