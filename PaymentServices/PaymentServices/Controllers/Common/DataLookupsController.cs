using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentServices.DataAccess.DomainRepository.Repository.Lookups;
using PaymentServices.DataAccess.Providers;
using PaymentServices.DataAccess.Providers.Contract;
using PaymentServices.Infrastructure.Response;
using PaymentServices.Models.API.Response.Lookups;
using PaymentServices.Models.DataTransfer.LookupsDTOs;
using PaymentServices.Models.Domain.Lookups;
using PaymentServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaymentServices.Controllers.Common
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class DataLookupsController : BaseController
    {
        private readonly ILookupsDataProvide _lookupManager;

        public DataLookupsController(ILookupsDataProvide _lookupManager, IDefaultDataProvider dataManager, IMapper mapper) : base(dataManager, mapper)
        {
            this._lookupManager = _lookupManager;
        }

        #region Country

        [HttpGet]
        [Route("country/all")]
        public async Task<ResponseBuilder> GetAllCountry()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<CountryResponse>>(await _lookupManager.Country.GetAll(filter: x=> !(x.isDeleted))) );
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("country/modify")]
        public async Task<ResponseBuilder> ManageCountry(Country country)
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<CountryResponse>(await _lookupManager.Country.ManageCountry(country)));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        #endregion

        #region Currency
        [HttpGet]
        [Route("currency/all")]
        public async Task<ResponseBuilder> GetAllCurrency()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<CurrencyResponce>>(await _lookupManager.Currency.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("Currency/modify")]
        public async Task<ResponseBuilder> ManageCurrency(Currency currency)
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<CurrencyResponce>(await _lookupManager.Currency.ManageCurrency(currency)));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #endregion
        #region Language
        [HttpGet]
        [Route("language/all")]
        public async Task<ResponseBuilder> GetAllLanguage()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<LanguageResponce>>(await _lookupManager.Language.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        [HttpPost]
        [Route("language/modify")]
        public async Task<ResponseBuilder> ManageLanguage(Language language)
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<LanguageResponce>(await _lookupManager.Language.ManageLanguage(language)));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #endregion
    }
}