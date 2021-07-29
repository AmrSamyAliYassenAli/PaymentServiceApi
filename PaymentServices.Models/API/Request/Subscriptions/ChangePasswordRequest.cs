using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Request.Subscriptions
{
    public class ChangePasswordRequest
    {
        public int userId { get; set; }
        public int companyId { get; set; }
        public string password { get; set; }
        public string oldPassword { get; set; }
    }
}
