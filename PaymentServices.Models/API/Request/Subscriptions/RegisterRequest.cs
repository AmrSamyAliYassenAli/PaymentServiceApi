using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Request.Subscriptions
{
    public class RegisterRequest
    {
        public int languageId { get; set; }
        public string email { get; set; }
        public string slogan { get; set; }
        public string firstName { get; set; }
        public string companyName { get; set; }

        public string website { get; set; }

        public string address { get; set; }
        public string phone { get; set; }

        public int phoneCountry { get; set; }

        public string fax { get; set; }

        public int faxCountry { get; set; }

        public int packageId { get; set; }
        public int businessType { get; set; } // 1. individual, 2.Corporate 
        public int sectorId { get; set; }

        public string contactEmail { get; set; }

        public string contactPhone { get; set; }

        public string contactName { get; set; }
        public string password { get; set; }
    }
}
