using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Security;
using PaymentServices.Models.API.Request.Security;
using PaymentServices.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Security
{
    public class WhitelistIPRepository : Repository<WhitelistIP> , IWhitelistIPRepository
    {
        private readonly MiddlewareDbContext _context;
        public WhitelistIPRepository(MiddlewareDbContext _db):base(_db)
        {
            _context = _db;
        }

        public async Task AddManyItems(List<WhitelistIP> whitelistIPs)
        {
            var _whitelistIP = new WhitelistIP();
            _context.WhitelistIP.AddRange(whitelistIPs.Where(x => x.id <=0 ));
            foreach (var item in whitelistIPs.Where(x => x.id > 0 && !x.isDeleted))
            {
                _whitelistIP = await _context.WhitelistIP.FirstOrDefaultAsync(x => x.id == item.id);

                if(_whitelistIP != null)
                {
                    _whitelistIP.IPAddress = item.IPAddress;
                    _whitelistIP.IPType = item.IPType;
                    _whitelistIP.modifiedAt = DateTime.UtcNow;
                }

            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<DeleteRequest> Ids)
        {
            foreach (var item in Ids)
            {
                var currentIP = await _context.WhitelistIP.FirstOrDefaultAsync(x => x.id == item.Id);

                if (currentIP != null)
                {
                    currentIP.isDeleted = true;

                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
