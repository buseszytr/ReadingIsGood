﻿using System;

namespace ReadingIsGood.Domain.Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
