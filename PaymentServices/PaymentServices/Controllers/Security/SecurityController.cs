using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentServices.DataAccess.Providers;
using PaymentServices.DataAccess.Providers.Contract;
using PaymentServices.Infrastructure.Response;
using PaymentServices.Infrastructure.Validation;
using PaymentServices.Models.API.Request.Security;
using PaymentServices.Models.API.Response.Security;
using PaymentServices.Models.Domain.Security;
using PaymentServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaymentServices.Controllers.Security
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class SecurityController : BaseController
    {

        private readonly ISecurityDataProvider _securityManager;
        
        public SecurityController(ISecurityDataProvider _securityManager,IDefaultDataProvider dataManager, IMapper mapper):base(dataManager,mapper)
        {
            this._securityManager = _securityManager;
        }

    #region WhitelistCountry
        [HttpGet]
        [Route("whitelistcountry/all")]
        public async Task<ResponseBuilder> GetAllWhitelistCountries()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<WhitelistResponse>>(await _securityManager.WhitelistCountry.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("whitelistcountry/modify")]
        public async Task<ResponseBuilder> ManageWhitelistCountry(List<WhitelistCountry> whitelistcountries)
        {
            try
            {
                await _securityManager.WhitelistCountry.AddManyItems(whitelistcountries);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("whitelistcountry/delete")]
        public async Task<ResponseBuilder> DeleteWhitelistCountry(List<DeleteRequest> Ids)
        {
            try
            {
                await _securityManager.WhitelistCountry.DeleteMany(Ids);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
    #endregion

    #region BlockCountry
        [HttpGet]
        [Route("blockcountry/all")]
        public async Task<ResponseBuilder> GetAllBlockCountries()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<BlockCountryResponse>>(await _securityManager.BlockCountry.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("blockcountry/modify")]
        public async Task<ResponseBuilder> ManageBlockCountry(List<BlockCountry> blockcountries)
        {
            try
            {
                await _securityManager.BlockCountry.AddManyItems(blockcountries);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("blockcountry/delete")]
        public async Task<ResponseBuilder> DeleteBlockCountries(List<DeleteRequest> Ids)
        {
            try
            {
                await _securityManager.BlockCountry.DeleteMany(Ids);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #endregion

    #region WhitelistIP
        [HttpGet]
        [Route("whitelistip/all")]
        public async Task<ResponseBuilder> GetAllWhitelistIPs()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<WhitelistIPResponse>>(await _securityManager.WhitelistIP.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("whitelistip/modify")]
        public async Task<ResponseBuilder> ManageWhitelistIP(List<WhitelistIP> whitelistIPs)
        {
            try
            {
                // Validate IP Address by it's type before adding/Updateing
                var _validWhitelistIps = new List<WhitelistIP>();
                
                foreach (var item in whitelistIPs)
                {// IP Address Type should be enum or entered with this format example [i Pv4,I pv 4,I  P v4,IPV4,iPv4,ipV4,etc] it will converte to lower case and remove any sapaces
                    if (ModelValidations.IPAddress_IsValid(item.IPAddress , item.IPType.ToLower().Trim())) 
                    {
                        _validWhitelistIps.Add(new WhitelistIP { 
                            IPAddress = item.IPAddress,
                            IPType = item.IPType
                        });
                    }
                }
                await _securityManager.WhitelistIP.AddManyItems(_validWhitelistIps);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("whitelistip/delete")]
        public async Task<ResponseBuilder> DeleteWhitelistIPs(List<DeleteRequest> Ids)
        {
            try
            {
                await _securityManager.WhitelistIP.DeleteMany(Ids);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #endregion

    #region BlockIP
        [HttpGet]
        [Route("blockip/all")]
        public async Task<ResponseBuilder> GetAllBlockIPs()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<BlockIPResponse>>(await _securityManager.BlockIP.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("blockip/modify")]
        public async Task<ResponseBuilder> ManageBlockIP(List<BlockIP> blockIPs)
        {
            try
            {
                // Validate IP Address by it's type before adding/Updateing
                var _validblockIPs = new List<BlockIP>();

                foreach (var item in blockIPs)
                {// IP Address Type should be enum or entered with this format example [i Pv4,I pv 4,I  P v4,IPV4,iPv4,ipV4,etc] it will converte to lower case and remove any sapaces
                    if (ModelValidations.IPAddress_IsValid(item.IPAddress, item.IPType.ToLower().Trim()))
                    {
                        _validblockIPs.Add(new BlockIP
                        {
                            IPAddress = item.IPAddress,
                            IPType = item.IPType
                        });
                    }
                }
                await _securityManager.BlockIP.AddManyItems(_validblockIPs);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("blockip/delete")]
        public async Task<ResponseBuilder> DeleteBlockIPs(List<DeleteRequest> Ids)
        {
            try
            {
                await _securityManager.BlockIP.DeleteMany(Ids);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #endregion

    #region BlockDomain
        [HttpGet]
        [Route("blockdomain/all")]
        public async Task<ResponseBuilder> GetAllBlockDomains()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<BlockDomainResponse>>(await _securityManager.BlockDomain.GetAll(filter: x => !(x.isDeleted))));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("blockdomain/modify")]
        public async Task<ResponseBuilder> ManageBlockDomain(List<BlockDomain> blockDomains)
        {
            try
            {
                await _securityManager.BlockDomain.AddManyItems(blockDomains);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("blockdomain/delete")]
        public async Task<ResponseBuilder> DeleteBlockDomains(List<DeleteRequest> Ids)
        {
            try
            {
                await _securityManager.BlockDomain.DeleteMany(Ids);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
    #endregion
    }
}
