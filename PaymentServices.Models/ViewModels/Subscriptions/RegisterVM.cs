using PaymentServices.Models.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.ViewModels.Subscriptions
{
    public class RegisterVM
    {
        public CompanyProfile company { get; set; }
        public CompanyUsers user { get; set; }
    }
}
