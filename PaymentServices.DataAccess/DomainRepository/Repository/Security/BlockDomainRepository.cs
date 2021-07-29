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
    public class BlockDomainRepository : Repository<BlockDomain> , IBlockDomainRepository
    {
        private readonly MiddlewareDbContext _context;

        public BlockDomainRepository(MiddlewareDbContext _db):base(_db)
        {
            _context = _db;
        }

        public async Task AddManyItems(List<BlockDomain> blockDomains)
        {
            var _blockDomain = new BlockDomain();
            var _blockDomainList = new List<BlockDomain>();


            foreach (var item in blockDomains.Where(x => x.id <= 0 && Uri.CheckHostName(x.domain).Equals("Dns") ))
            {
                _blockDomainList.Add(item);
            }

            _context.BlockDomain.AddRange(_blockDomainList);
            foreach (var item in blockDomains.Where(x => x.id > 0 && !x.isDeleted))
            {
                _blockDomain = await _context.BlockDomain.FirstOrDefaultAsync(x => x.id == item.id);

                if (_blockDomain != null)
                {
                    _blockDomain.id = item.id;
                    _blockDomain.modifiedAt = DateTime.UtcNow;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<DeleteRequest> Ids)
        {
            foreach (var item in Ids)
            {
                var currentCountry = await _context.BlockDomain.FirstOrDefaultAsync(x => x.id == item.Id);

                if (currentCountry != null)
                {
                    currentCountry.isDeleted = true;

                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
