using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Infrastructure.StaticData
{
    public static class ValidationMessages
    {
        public const string CantDeletePrice = "Can't delete price."; 
        public const string PackagePriceNeeded = "Package price needed."; 
        public const string InvalidData = "Invalid Data."; 
        public const string InvalidUserCredentials = "Invalid User Credentials."; 
        public const string RequiredEmail = "Email is required."; 
        public const string RequiredPassword = "Password is required."; 
        public const string InvalidEmailFormat = "Invalid Email Format."; 
        public const string PasswordChars = "Password must contain characters."; 
        public const string PasswordDigits = "Password must contain digits."; 
        public const string PasswordLength = "Password length must be 8 characters."; 
        public const string ReuiredSector = "Sector is required."; 
        public const string RequiredBusinessType = "Business type is required."; 
        public const string RequiredWebsite = "Website is required."; 
        public const string RequiredPhone = "Phone is required."; 
        public const string RequiredPhoneCountry = "Phone country is required."; 
        public const string RequiredContactEmail = "Contact email is required."; 
        public const string RequiredContactPhone = "Contact phone is required."; 
        public const string InvalidContactEmail = "Invalid contact email format."; 
        public const string InValidPackage = "InValid Package."; 
        public const string RequiredUserId = "User id is required."; 
        public const string RequiredCompanyId = "Company id is required."; 
        public const string RequiredOldPassword = "Old password is required."; 
        public const string InvalidUser = "Invalid User."; 
        public const string InvalidCompany = "Invalid Company."; 
        public const string InvalidUserUnderCompany = "User not exist in this company."; 
        public const string InvalidUserPassword = "Invalid user password."; 
       
    }
}
