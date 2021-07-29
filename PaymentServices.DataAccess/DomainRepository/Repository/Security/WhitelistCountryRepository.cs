using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Security;
using PaymentServices.Models.API.Request.Security;
using PaymentServices.Models.API.Response.Security;
using PaymentServices.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Security
{
    public class WhitelistCountryRepository : Repository<WhitelistCountry>, IWhitelistCountryRepository
    {
        private readonly MiddlewareDbContext _context;
        public WhitelistCountryRepository(MiddlewareDbContext _db):base(_db)
        {
            _context = _db;
        }

        public async Task AddManyItems(List<WhitelistCountry> whitelistCountries)
        {
            var _whitelistCountry = new WhitelistCountry();
            _context.WhitelistCountry.AddRange(whitelistCountries.Where(x => x.id <= 0));
            foreach (var item in whitelistCountries.Where(x => x.id > 0 && !x.isDeleted))
            {
                _whitelistCountry = await _context.WhitelistCountry.FirstOrDefaultAsync(x => x.id == item.id);
                if (_whitelistCountry != null)
                {
                    _whitelistCountry.countryId = item.countryId;
                    _whitelistCountry.modifiedAt = DateTime.UtcNow;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<DeleteRequest> Ids)
        {
            foreach (var item in Ids)
            {
                var currentCountry = await _context.WhitelistCountry.FirstOrDefaultAsync(x => x.id == item.Id);

                if (currentCountry != null)
                {
                    currentCountry.isDeleted = true;

                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
