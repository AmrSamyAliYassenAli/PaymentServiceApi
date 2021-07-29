using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Packages;
using PaymentServices.Models.Domain.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Packages
{
    public class SubscriptionPackagePricesRepository : Repository<SubscriptionPackagePrices>, ISubscriptionPackagePricesRepository
    {
        private readonly MiddlewareDbContext _context;

        public SubscriptionPackagePricesRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }
        public async Task DeleteMany(List<SubscriptionPackagePrices> packages) 
        {
            foreach (var item in packages)
            {
                var currPckes = await _context.SubscriptionPackagePrices.FirstOrDefaultAsync(x => x.packagePriceId == item.packagePriceId);

                if (currPckes != null)
                {
                    currPckes.isDeleted = true;
                  
                }
            }
            await _context.SaveChangesAsync();
        } 
        public async Task AddManyItems(List<SubscriptionPackagePrices> packagePrices)
        { 
                var currPckes = new SubscriptionPackagePrices();
                _context.SubscriptionPackagePrices.AddRange(packagePrices.Where(x => x.packagePriceId <= 0));
            
                foreach (var item in packagePrices.Where(x => x.packagePriceId > 0 && !x.isDeleted))
                {
                    currPckes = await _context.SubscriptionPackagePrices.FirstOrDefaultAsync(x => x.packageId == item.packageId);

                    if (currPckes != null)
                    {
                        currPckes.price = item.price;
                        currPckes.countryId = item.countryId;
                        currPckes.isMonthly = item.isMonthly;
                        currPckes.isYearly = item.isYearly;
                        currPckes.modifiedAt = DateTime.UtcNow;
                    }
                }
                await _context.SaveChangesAsync(); 
        }
        public async Task<List<SubscriptionPackagePrices>> GetPricesOfPackage(int id)
        {
            var prices = await _context.SubscriptionPackagePrices.Where(x => x.packageId == id).ToListAsync();
            if (prices != null && prices.Count >0)
            {
                return prices;
            }
            return new List<SubscriptionPackagePrices>();
        }
    }
}
