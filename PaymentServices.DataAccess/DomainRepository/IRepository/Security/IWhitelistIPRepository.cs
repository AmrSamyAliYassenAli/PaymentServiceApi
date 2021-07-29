using PaymentServices.Models.API.Request.Security;
using PaymentServices.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Security
{
    public interface IWhitelistIPRepository : IRepository<WhitelistIP>
    {
        Task AddManyItems(List<WhitelistIP> whitelistIPs);
        Task DeleteMany(List<DeleteRequest> Ids);
    }
}
