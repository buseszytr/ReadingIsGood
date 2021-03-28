using System;
using ReadingIsGood.Domain.Models;

namespace ReadingIsGood.Domain.ResponseModels
{
    public class UserResponse : BaseResponse
    {
        public User user { get; set; }
        public UserResponse(bool success, string message, User user) : base(success, message)
        {
            this.user = user;
        }
        public UserResponse(User user) : this(true, String.Empty, user) { }
        public UserResponse(string message) : this(false, message, null) { }
    }
}
