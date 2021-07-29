using PaymentServices.Models.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Lookups
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<Currency> ManageCurrency(Currency currency);
    }
}
