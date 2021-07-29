using AutoMapper;
using PaymentServices.Models.API.Request.Subscriptions;
using PaymentServices.Models.API.Response.Lookups;
using PaymentServices.Models.API.Response.Security;
using PaymentServices.Models.API.Response.Subscriptions;
using PaymentServices.Models.Domain.Lookups;
using PaymentServices.Models.Domain.Security;
using PaymentServices.Models.Domain.Subscriptions;
using PaymentServices.Models.ViewModels.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.ServiceConfig.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region DataLookups
                CreateMap<Country, CountryResponse>();
                CreateMap<Currency, CurrencyResponce>();
                CreateMap<Language, LanguageResponce>();
            #endregion

            #region Security
                CreateMap<WhitelistCountry, WhitelistResponse>();
                CreateMap<BlockCountry, BlockCountryResponse>();
                CreateMap<WhitelistIP, WhitelistIPResponse>();
                CreateMap<BlockIP, BlockIPResponse>();
                CreateMap<BlockDomain, BlockDomainResponse>();
            #endregion

            #region Subscriptions
                CreateMap<CompanyUsers, User>();
                CreateMap<CompanyProfile, CompanyDetails>();
                CreateMap<AccessRoles, RoleDetails>();
                CreateMap<RegisterRequest, CompanyProfile>();
                CreateMap<RegisterRequest, CompanyUsers>();
                CreateMap<CompanyUsers, CompanyUsersResponse>();
                CreateMap<CompanyProfile, CompanyProfileResponce>();
                CreateMap<ProfileDetailsVM, MerchantProfileDetailsResponse>();
            #endregion
        }
    }
}
