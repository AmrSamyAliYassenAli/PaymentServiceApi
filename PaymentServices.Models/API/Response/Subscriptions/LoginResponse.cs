using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Subscriptions
{
    public class LoginResponse
    { 
        public User user { get; set; }
        public CompanyDetails company { get; set; }
        public RoleDetails role { get; set; }

    }
    public class User
    {
        public int userId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
        public string email { get; set; }
    }
    public class CompanyDetails
    {
        public int companyId { get; set; }

        public int languageId { get; set; }

        public string slogan { get; set; }

        public string email { get; set; }

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
    }
    public class RoleDetails
    {
        public int roleId { get; set; }

        public string name { get; set; }

        public int accessType { get; set; }
    }
}
