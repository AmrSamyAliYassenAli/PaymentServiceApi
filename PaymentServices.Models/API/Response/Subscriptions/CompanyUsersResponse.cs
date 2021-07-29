using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Subscriptions
{
    public class CompanyUsersResponse
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string about { get; set; }
        public bool isActive { get; set; }
    }
}
