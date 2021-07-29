using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentServices.DataAccess.Providers;
using PaymentServices.DataAccess.Providers.Contract;
using PaymentServices.Infrastructure.Encryption;
using PaymentServices.Infrastructure.Response;
using PaymentServices.Infrastructure.StaticData;
using PaymentServices.Infrastructure.Validation;
using PaymentServices.Models.API.Request;
using PaymentServices.Models.API.Request.Subscriptions;
using PaymentServices.Models.API.Response.Subscriptions;
using PaymentServices.Models.Domain.Packages;
using PaymentServices.Models.Domain.Subscriptions;
using PaymentServices.Models.ViewModels.Subscriptions;
using PaymentServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaymentServices.Controllers.Subscriptions
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class SubscriptionsController : BaseController
    { 
        private readonly ISubscriptionDataProvider _subscriptionManager;
        private readonly IPackageDataProvider _packageManager;
        private readonly IEncryption _encryption;

        public SubscriptionsController(IDefaultDataProvider dataManager, IMapper mapper, ISubscriptionDataProvider subscriptionManager, IPackageDataProvider packageManager, IEncryption encryption) : base(dataManager, mapper)
        { 
            _subscriptionManager = subscriptionManager;
            _encryption = encryption;
            _packageManager = packageManager;
        }
    #region Registeration & Login  (Maha Wanas) Task
        [HttpPost]
        [Route("subscription/login")]
        public async Task<ResponseBuilder> Login(LoginRequest login)
        {
            try
            {
                List<string> validationMessages = new List<string>();
                if (string.IsNullOrEmpty(login.email))
                    validationMessages.Add(ValidationMessages.RequiredEmail);

                if (!string.IsNullOrEmpty(login.email) && !ModelValidations.IsValidEmail(login.email))
                    validationMessages.Add(ValidationMessages.InvalidEmailFormat);

                if (string.IsNullOrEmpty(login.password))
                    validationMessages.Add(ValidationMessages.RequiredPassword);

                var user = await _subscriptionManager.CompanyUsers.Login(login.email, _encryption.Encrypt(login.password));
                LoginResponse log = new LoginResponse()
                {
                    user = _mapper.Map<User>(user),
                    company = _mapper.Map<CompanyDetails>(user.CompanyProfile),
                    role = _mapper.Map<RoleDetails>(user.AccessRole),
                   
                };
          
               if (validationMessages.Count ==0 && user.userId > 0)
                  return ResponseBuilder.Create(HttpStatusCode.OK, log);
               else
                    return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), validationMessages);
                

            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("subscription/register")]
        public async Task<ResponseBuilder> Register(RegisterRequest register)
        {
            try
            {
                var validMsgs =await ValidateRegistration(register);
               
                if (validMsgs != null && validMsgs.Count ==0)
                {
                    register.password = _encryption.Encrypt(register.password);
                    RegisterVM registerModel = new RegisterVM() { 
                       company = _mapper.Map<CompanyProfile>(register),
                       user = _mapper.Map<CompanyUsers>(register)
                    };
                    registerModel.user.roleId = CommonValues.CompanyAdminRoleId;
                    var company = await _subscriptionManager.CompanyProfile.Register(registerModel);
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<CompanyDetails>(company));
                }
                else
                    return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), validMsgs);
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("subscription/changePassword")]
        public async Task<ResponseBuilder> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var validMsgs = await ValidateChangePassword(request);
                if (validMsgs != null && validMsgs.Count == 0)
                {
                   await _subscriptionManager.CompanyUsers.ChangePassword(request.userId, _encryption.Encrypt(request.oldPassword), _encryption.Encrypt(request.password));
                    return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
                }
                else
                    return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), validMsgs);
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        #region private
        async Task<List<string>> ValidateRegistration(RegisterRequest register)
        {
            List<string> validationMessages = new List<string>();
            if (register == null)
                validationMessages.Add(ValidationMessages.InvalidData);
            else if(!await _packageManager.SubscriptionPackages.IsValidPackage(register.packageId))
                validationMessages.Add(ValidationMessages.InValidPackage);

            else
            { 
                if (string.IsNullOrEmpty(register.email))
                    validationMessages.Add(ValidationMessages.RequiredEmail);
                else if(!string.IsNullOrEmpty(register.email) && !ModelValidations.IsValidEmail(register.email))
                    validationMessages.Add(ValidationMessages.InvalidEmailFormat);

                if (string.IsNullOrEmpty(register.password))
                    validationMessages.Add(ValidationMessages.RequiredPassword);
                else
                {
                    var passwordErrors = ModelValidations.ValidatePassword(register.password);
                    if (passwordErrors.Count > 0)
                        validationMessages.AddRange(passwordErrors);
                }

                 if(register.businessType <=0)
                    validationMessages.Add(ValidationMessages.RequiredBusinessType);

                if (register.sectorId <= 0)
                    validationMessages.Add(ValidationMessages.ReuiredSector);

                if (string.IsNullOrEmpty(register.website))
                    validationMessages.Add(ValidationMessages.RequiredWebsite);

                if (string.IsNullOrEmpty(register.phone))
                    validationMessages.Add(ValidationMessages.RequiredPhone);

                if (register.phoneCountry <= 0)
                    validationMessages.Add(ValidationMessages.RequiredPhoneCountry);

                if (string.IsNullOrEmpty(register.contactEmail))
                    validationMessages.Add(ValidationMessages.RequiredContactEmail);
                else if(!ModelValidations.IsValidEmail(register.contactEmail))
                    validationMessages.Add(ValidationMessages.InvalidContactEmail);

                if (string.IsNullOrEmpty(register.contactPhone))
                    validationMessages.Add(ValidationMessages.RequiredContactPhone);
            }
            return validationMessages;
        }

        async Task<List<string>> ValidateChangePassword(ChangePasswordRequest request)
        {
            List<string> validationMessages = new List<string>();

            if (request == null)
                validationMessages.Add(ValidationMessages.InvalidData);

            else
            {
                bool modelsError = false;
                bool passwordError = false;
                if (request.userId <= 0)
                {
                    modelsError = true;
                    validationMessages.Add(ValidationMessages.RequiredUserId);
                }
                else if (!await _subscriptionManager.CompanyUsers.IsValidUserById(request.userId))
                {
                    modelsError = true;
                    validationMessages.Add(ValidationMessages.InvalidUser);
                }

                else if (request.companyId <= 0)
                {
                    modelsError = true;
                    validationMessages.Add(ValidationMessages.RequiredCompanyId);
                }
                else if (!await _subscriptionManager.CompanyProfile.IsValidCompany(request.companyId))
                {
                    modelsError = true;
                    validationMessages.Add(ValidationMessages.InvalidCompany);
                }
                else if (!await _subscriptionManager.CompanyUsers.UserExistsInCompany(request.userId,request.companyId))
                {
                    modelsError = true;
                    validationMessages.Add(ValidationMessages.InvalidUserUnderCompany);
                }

                if (!modelsError)
                {
                    if (string.IsNullOrEmpty(request.oldPassword))
                    {
                        validationMessages.Add(ValidationMessages.RequiredOldPassword);
                        passwordError = true;
                    }
                    else if (!await _subscriptionManager.CompanyUsers.IsValidUserPassword(request.userId, _encryption.Encrypt(request.oldPassword)))
                    {
                        passwordError = true;
                        validationMessages.Add(ValidationMessages.InvalidUserPassword);
                    }

                    if (!passwordError)
                    {
                        if (string.IsNullOrEmpty(request.password))
                            validationMessages.Add(ValidationMessages.RequiredPassword);
                        else
                        {
                            var passwordErrors = ModelValidations.ValidatePassword(request.password);
                            if (passwordErrors.Count > 0)
                                validationMessages.AddRange(passwordErrors);
                        }
                    }
                }
            }
            return validationMessages;
        }
        #endregion
        #endregion

    #region CompanyUsers CRUD (Amr Samy) Task

        [HttpGet]
        [Route("companyusers/allusersofcompany")]
        public async Task<ResponseBuilder> GetAllUsersofCompany(int id)
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<CompanyUsersResponse>>(await _subscriptionManager.CompanyUsers.GetAllUsersofCompany(id)));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
       
        [HttpPost]
        [Route("companyusers/modify")]
        public async Task<ResponseBuilder> ManageCompanyUsers(List<CompanyUsers> companyUsers)
        {
            try
            {
                await _subscriptionManager.CompanyUsers.AddManyItems(companyUsers);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpGet]
        [Route("profiles/getall")]
        public async Task<ResponseBuilder> GetAllUserProfiles()
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<CompanyProfileResponce>>(await _subscriptionManager.CompanyProfile.GetAll(filter: x => x.isActive)));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #region Manage Merchant
        [HttpPost]
        [Route("profiles/blockmerchant")]
        public async Task<ResponseBuilder> BlockMerchant(BlockMerchantRequest blockMerchantRequest)
        {
            try
            {
                await _subscriptionManager.CompanyProfile.BlockMerchant(blockMerchantRequest.merchantId);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        [HttpPost]
        [Route("profiles/merchantprofiledetails")]
        public async Task<ResponseBuilder> MerchantProfileDetails(MerchantRequest merchantRequest)
        {
            try
            {
                return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<MerchantProfileDetailsResponse>(await _subscriptionManager.CompanyProfile.GetProfileDetails(merchantRequest.merchantId)));
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }

        [HttpPost]
        [Route("profiles/modify")]
        public async Task<ResponseBuilder> ManageCurrency(ProfileRequest companyProfile)
        {
            try
            {
                await _subscriptionManager.CompanyProfile.Modify(companyProfile);
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = true });
            }
            catch (Exception ae)
            {
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new object(), new string[] { ae.Message });
            }
        }
        #endregion
        #endregion
    }
}
