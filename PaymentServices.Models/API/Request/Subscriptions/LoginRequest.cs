﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Request.Subscriptions
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
