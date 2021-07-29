using PaymentServices.DataAccess.DomainRepository.IRepository.Lookups;
using PaymentServices.Models.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace PaymentServices.DataAccess.DomainRepository.Repository.Lookups
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly MiddlewareDbContext _context;

        public CountryRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }

        public async Task<Country> ManageCountry(Country country)
        {
            if(country.id <= 0)
            {
                _context.Country.Add(country);
            }
            else
            {
                var _temp = await _context.Country.FirstOrDefaultAsync(x => x.id == country.id);

                if(_temp != null)
                {
                    _temp.name = country.name;
                    _temp.currencyId = country.currencyId;
                    _temp.modifiedAt = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();

            return country;
        }
    }
}
