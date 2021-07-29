using PaymentServices.DataAccess.DomainRepository.IRepository.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Contract
{
    public interface ISecurityDataProvider : IDisposable
    {
        IBlockCountryRepository BlockCountry { get; }
        IBlockIPRepository BlockIP { get; }
        IWhitelistCountryRepository WhitelistCountry { get; }
        IWhitelistIPRepository WhitelistIP { get; }
        IBlockDomainRepository BlockDomain { get; }
        Task Save();
    }
}
