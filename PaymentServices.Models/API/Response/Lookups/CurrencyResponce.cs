using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Lookups
{
    public class CurrencyResponce
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool isDefault { get; set; }
        public decimal convertionRate { get; set; }
        public int sortOrder { get; set; }
        public bool active { get; set; }
    }
}
