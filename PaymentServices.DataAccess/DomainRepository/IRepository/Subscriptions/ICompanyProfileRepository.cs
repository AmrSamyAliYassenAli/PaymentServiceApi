using PaymentServices.Models.API.Request.Subscriptions;
using PaymentServices.Models.Domain.Subscriptions;
using PaymentServices.Models.ViewModels.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions
{
    public interface ICompanyProfileRepository : IRepository<CompanyProfile>
    {
        Task<CompanyProfile> Register(RegisterVM register);
        Task<bool> IsValidCompany(int id);
        Task BlockMerchant(int merchantId);
        Task<ProfileDetailsVM> GetProfileDetails(int merchantId);
        Task Modify(ProfileRequest companyProfile);
    }
}
