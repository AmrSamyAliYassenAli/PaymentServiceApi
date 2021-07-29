using PaymentServices.Models.API.Request.Security;
using PaymentServices.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Security
{
    public interface IWhitelistCountryRepository : IRepository<WhitelistCountry>
    {
        Task AddManyItems(List<WhitelistCountry> whitelistCountries);
        Task DeleteMany(List<DeleteRequest> Ids);
    }
}
