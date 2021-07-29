using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Lookups
{
    public class CountryResponse
    {
        public int id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string isoCode { get; set; }

        public int currencyId { get; set; }
    }
}
