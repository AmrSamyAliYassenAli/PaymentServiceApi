using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using PaymentServices.Models.API.Request.Subscriptions;
using PaymentServices.Models.Domain.Subscriptions;
using PaymentServices.Models.ViewModels.Packages;
using PaymentServices.Models.ViewModels.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Subscriptions
{
    public class CompanyProfileRepository : Repository<CompanyProfile>, ICompanyProfileRepository
    {
        private readonly MiddlewareDbContext _context;

        public CompanyProfileRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }
        public async Task<CompanyProfile> Register(RegisterVM register)
        { 
                _context.CompanyProfile.Add(register.company);
                await _context.SaveChangesAsync();

                register.user.companyId = register.company.companyId;
                _context.CompanyUsers.Add(register.user);
                await _context.SaveChangesAsync();
                return register.company; 
           
        }
        public async Task<bool> IsValidCompany(int id)
        {
            var company = await _context.CompanyProfile.Where(x => x.companyId == id).FirstOrDefaultAsync();
            if (company != null) return true;
            else return false;
        }

        public async Task BlockMerchant(int merchantId)
        {
            var currentMerchant = await _context.CompanyProfile.FirstOrDefaultAsync(x=>x.companyId == merchantId);
            
            if(currentMerchant != null)
            {
                currentMerchant.isActive = false;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ProfileDetailsVM> GetProfileDetails(int merchantId)
        { 
            var currentMerchant = await _context.CompanyProfile.FirstOrDefaultAsync(x => x.companyId == merchantId);
            var noOfUsers = await _context.CompanyUsers.Where(x=>x.companyId == merchantId).ToListAsync();            
            var subPackage = await _context.SubscriptionPackages.FirstOrDefaultAsync(x => x.packageId == currentMerchant.packageId);

            if (currentMerchant != null && noOfUsers != null && subPackage != null)
            {
                var _ProfileDetailsVM = new ProfileDetailsVM
                {
                    ProfileVM = new ProfileVM
                    {
                        address = currentMerchant.address,
                        businessType = currentMerchant.businessType,
                        companyName = currentMerchant.companyName,
                        contactEmail = currentMerchant.contactEmail,
                        contactPhone = currentMerchant.contactPhone,
                        contactName = currentMerchant.contactName,
                        slogan = currentMerchant.slogan,
                        fax = currentMerchant.fax,
                        faxCountry = currentMerchant.faxCountry,
                        phone = currentMerchant.phone,
                        phoneCountry = currentMerchant.phoneCountry,
                        website = currentMerchant.website,
                        isVerificationNeeded = currentMerchant.isVerificationNeeded,
                        isActive = currentMerchant.isActive
                    },
                    NoOfUsers = noOfUsers.Count(),
                    SubscriptionPackagesVM = new SubscriptionPackagesVM
                    {
                        name = subPackage.name,
                        description = subPackage.description,
                        noOfBranches = subPackage.noOfBranches,
                        noOfUsers = subPackage.noOfUsers,
                        packageId = subPackage.packageId
                    }
                };
                return _ProfileDetailsVM;
            }
            else
            {
                return null;
            }
        }

        public async Task Modify(ProfileRequest companyProfile)
        {
            var _currentProfile = await _context.CompanyProfile.FirstOrDefaultAsync(x=>x.companyId == companyProfile.companyId);
            
            if (_currentProfile != null)
            {
                _currentProfile.contactEmail = companyProfile.contactEmail;
                _currentProfile.companyName = companyProfile.companyName;
                _currentProfile.contactName = companyProfile.contactName;
                _currentProfile.contactPhone = companyProfile.contactPhone;
                _currentProfile.fax = companyProfile.fax;
                _currentProfile.faxCountry = companyProfile.faxCountry;
                _currentProfile.phone = companyProfile.phone;
                _currentProfile.phoneCountry = companyProfile.phoneCountry;
                _currentProfile.slogan = companyProfile.slogan;
                _currentProfile.address = companyProfile.address;
                _currentProfile.website = companyProfile.website;
                _currentProfile.businessType = companyProfile.businessType;
            }
            await _context.SaveChangesAsync();
        }
    }
}
