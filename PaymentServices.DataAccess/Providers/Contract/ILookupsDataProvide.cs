using PaymentServices.DataAccess.DomainRepository.IRepository.Lookups;
using PaymentServices.DataAccess.DomainRepository.Repository.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Contract
{
    public interface ILookupsDataProvide : IDisposable
    {
        ICountryRepository Country { get; }
        ICurrencyRepository Currency { get; }
        ILanguageRepository Language { get; }
        Task Save();
    }
}
