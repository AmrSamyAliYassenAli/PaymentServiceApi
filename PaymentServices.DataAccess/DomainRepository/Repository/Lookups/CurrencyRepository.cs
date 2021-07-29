using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Lookups;
using PaymentServices.Models.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Lookups
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private readonly MiddlewareDbContext _context;

        public CurrencyRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }

        public async Task<Currency> ManageCurrency(Currency currency)
        { 
            if(currency.id <=0)
            {
                _context.Currency.Add(currency);
            }
            else
            {
                var _temp = await _context.Currency.FirstOrDefaultAsync(x=>x.id == currency.id);
                
                if(_temp != null)
                {
                    _temp.name = currency.name;
                    _temp.code = currency.code;
                    _temp.convertionRate = currency.convertionRate;
                    _temp.modifiedAt = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();

            return currency;
        }
    }
}
