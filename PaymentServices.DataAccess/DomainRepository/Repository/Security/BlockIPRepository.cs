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
    public class BlockIPRepository : Repository<BlockIP>, IBlockIPRepository
    {
        private readonly MiddlewareDbContext _context;
        public BlockIPRepository(MiddlewareDbContext _db):base(_db)
        {
            _context = _db;
        }
        public async Task AddManyItems(List<BlockIP> blockIPs)
        {
            var _blockIP = new BlockIP();
            _context.BlockIP.AddRange(blockIPs.Where(x=>x.id <=0));
            foreach (var item in blockIPs.Where(x=>x.id>0 && !x.isDeleted))
            {
                _blockIP = await _context.BlockIP.FirstOrDefaultAsync(x=>x.id == item.id);

                if (_blockIP != null)
                {
                    _blockIP.IPAddress = item.IPAddress;
                    _blockIP.IPType = item.IPType;
                    _blockIP.modifiedAt = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<DeleteRequest> Ids)
        {
            foreach (var item in Ids)
            {
                var currentIP = await _context.BlockIP.FirstOrDefaultAsync(x => x.id == item.Id);

                if (currentIP != null)
                {
                    currentIP.isDeleted = true;

                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
