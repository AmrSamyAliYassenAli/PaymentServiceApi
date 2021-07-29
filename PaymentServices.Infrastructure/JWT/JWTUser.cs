using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Infrastructure.JWT
{
    public class JWTUser
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
