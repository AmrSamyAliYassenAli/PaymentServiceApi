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
    public class SubscriptionPackagesRepository : Repository<SubscriptionPackages>, ISubscriptionPackagesRepository
    {
        private readonly MiddlewareDbContext _context;  

        public SubscriptionPackagesRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db; 
        } 
        public async Task<bool> CreateSubscriptionPackage(SubscriptionPackages package)
        {
            if(package.packageId <= 0)
            {
                _context.SubscriptionPackages.Add(package);
                _context.SaveChanges(); 
            }
            else
            {
                var pck = await _context.SubscriptionPackages.Where(x => x.packageId == package.packageId && !x.isDeleted).FirstOrDefaultAsync();
                if (pck != null)
                {
                    pck.name = package.name;
                    pck.description = package.description;
                    pck.noOfUsers = package.noOfUsers;
                    pck.noOfBranches = package.noOfBranches;
                    pck.modifiedAt = DateTime.UtcNow;
                    _context.SaveChanges();
                }
                else return false;
            }
            return true;
        }
        public async Task<bool> IsValidPackage(int id)
        {
            var package = await _context.SubscriptionPackages.Where(x => x.packageId == id && !x.isDeleted).FirstOrDefaultAsync();
            if (package != null)
                return true;
            else
                return false;
        }
    }
}
