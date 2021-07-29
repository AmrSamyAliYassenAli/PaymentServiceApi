using PaymentServices.Models.Domain.Subscriptions;
using PaymentServices.Models.ViewModels.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions
{
    public interface ICompanyUsersRepository : IRepository<CompanyUsers>
    {
        Task<CompanyUsers> IsValidUser(string email, string password);
        Task<CompanyUsers> Login(string email, string password);
        Task ChangePassword(int userId, string oldPassword, string newPassword);
        Task<bool> IsValidUserById(int id);
        Task<bool> UserExistsInCompany(int userId, int companyId);
        Task<bool> IsValidUserPassword(int userId, string password);
        Task<List<CompanyUsers>> GetAllUsersofCompany(int id);
        Task AddManyItems(List<CompanyUsers> companyUsers);        
    }
}
