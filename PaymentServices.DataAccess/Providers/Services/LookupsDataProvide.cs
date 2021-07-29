using PaymentServices.DataAccess.DomainRepository;
using PaymentServices.DataAccess.DomainRepository.IRepository.Lookups;
using PaymentServices.DataAccess.DomainRepository.Repository.Lookups;
using PaymentServices.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Services
{
    public class LookupsDataProvide : ILookupsDataProvide
    {
        private readonly MiddlewareDbContext _db;

        public LookupsDataProvide(MiddlewareDbContext db)
        {
            _db = db;
            Country = new CountryRepository(_db);
            Currency = new CurrencyRepository(_db);
            Language = new LanguageRepository(_db);
        }

        public ICountryRepository Country { get; private set; }
        public ICurrencyRepository Currency { get; private set; }
        public ILanguageRepository Language { get; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
