using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaymentServices.DataAccess.Providers;
using PaymentServices.DataAccess.Providers.Contract;
using PaymentServices.Infrastructure.JWT;
using PaymentServices.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaymentServices.Security
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[ServiceFilter(typeof(AuditLogFilter))]
    public class BaseController : ControllerBase
    {
        public readonly IDefaultDataProvider _dataManager;
        public readonly IMapper _mapper;

        public BaseController(IDefaultDataProvider dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
           
        }
    }

    [ApiController]
    [AllowAnonymous]
    public class JWTAuth : BaseController
    {
        private readonly JWTSettings _jwtsettings;
        public readonly ISubscriptionDataProvider _subscriptionManager;

        public JWTAuth(IDefaultDataProvider dataManager, IMapper mapper, IOptions<JWTSettings> jwtsettings, ISubscriptionDataProvider subscriptionManager) : base(dataManager, mapper)
        {
            _jwtsettings = jwtsettings.Value;
            _subscriptionManager = subscriptionManager;
        }

        [HttpPost]
        [Route("api/authorize")]
        public async Task<ResponseBuilder> AuthorizeRequest([FromBody] JWTUser signIn)
        {
            try
            {
                var _tempAuth = await _subscriptionManager.CompanyUsers.IsValidUser(signIn.email, signIn.password);

                if (_tempAuth != null)
                { 
                    return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true, token = TokenManager.GenerateAccessToken(_tempAuth.userId, _jwtsettings.SecretKey) });
                }
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false, message = ae.Message });
            }

            return ResponseBuilder.Create(HttpStatusCode.OK, new { status = false, token = string.Empty });
        }
    }
}
