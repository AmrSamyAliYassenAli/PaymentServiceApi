using PaymentServices.Infrastructure.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Infrastructure.Validation
{
    public static class ModelValidations
    {
    #region Subscription Validation
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static List<string> ValidatePassword(string password)
        {
            try
            {
                List<string> messages = new List<string>();

                if (!password.Any(c => char.IsLetter(c)))
                    messages.Add(ValidationMessages.PasswordChars);

                if (!password.Any(c => char.IsDigit(c)))
                    messages.Add(ValidationMessages.PasswordDigits);

                if (password.Length != 8)
                    messages.Add(ValidationMessages.PasswordLength);
                return messages;
            }
            catch(Exception ex)
            {
                return new List<string>() { ex.Message };
            }
        }
        #endregion

        #region Security Validation
        // Domain Regular Expressions (http[s]?:\/\/|[a-z]*\.[a-z]{3}\.[a-z]{2})([a-z]*\.[a-z]{3})|([a-z]*\.[a-z]*\.[a-z]{3}\.[a-z]{2})|([a-z]+\.[a-z]{3})
        public static bool IPAddress_IsValid(string IpAddress, string type)
        {

            bool flag = false;
            if (!string.IsNullOrWhiteSpace(IpAddress))
            {
                IPAddress ip;
                if (IPAddress.TryParse(IpAddress, out ip))
                {
                    if (type == "ipv4")
                    {
                        flag = ip.AddressFamily == AddressFamily.InterNetwork;
                    }
                    else if (type == "ipv6")
                    {
                        flag = ip.AddressFamily == AddressFamily.InterNetworkV6;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    #endregion
    }
}
