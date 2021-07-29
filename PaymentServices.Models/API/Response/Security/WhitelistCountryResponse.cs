using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Security
{
    public class WhitelistCountryResponse
    {
        public int id { get; set; }
        public int countryId { get; set; }
    }
}
