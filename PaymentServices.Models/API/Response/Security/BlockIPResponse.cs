using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Security
{
    public class BlockIPResponse
    {
        public int id { get; set; }
        public string IPAddress { get; set; }
        public string IPType { get; set; }
    }
}
