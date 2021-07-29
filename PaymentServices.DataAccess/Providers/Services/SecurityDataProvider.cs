using PaymentServices.DataAccess.DomainRepository;
using PaymentServices.DataAccess.DomainRepository.IRepository.Security;
using PaymentServices.DataAccess.DomainRepository.Repository.Security;
using PaymentServices.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Services
{
    public class SecurityDataProvider : ISecurityDataProvider
    {
        private readonly MiddlewareDbContext _db;
        public SecurityDataProvider(MiddlewareDbContext _db)
        {
            this._db = _db;
            BlockCountry = new BlockCountryRepository(_db);
        }
        public IBlockCountryRepository BlockCountry { get; private set; }
        public IBlockIPRepository BlockIP { get; private set; }
        public IWhitelistCountryRepository WhitelistCountry { get; private set; }
        public IWhitelistIPRepository WhitelistIP { get; private set; }
        public IBlockDomainRepository BlockDomain { get; private set; }
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
