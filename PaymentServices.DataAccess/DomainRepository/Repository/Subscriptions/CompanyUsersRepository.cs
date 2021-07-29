using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using PaymentServices.Infrastructure.Encryption;
using PaymentServices.Models.Domain.Subscriptions; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Subscriptions
{
    public class CompanyUsersRepository : Repository<CompanyUsers>, ICompanyUsersRepository
    {
        private readonly MiddlewareDbContext _context;
        private readonly IEncryption _encryption;
        public CompanyUsersRepository(MiddlewareDbContext db, IEncryption _encryption) : base(db)
        {
            _context = db;
            this._encryption = _encryption;
        }
        public async Task<CompanyUsers> IsValidUser(string email, string password)
        {
            return await _context.CompanyUsers.Where(x => x.email == email && x.password == password).FirstOrDefaultAsync();
             
        }
        public async Task<bool> IsValidUserById(int id)
        {
            var user = await _context.CompanyUsers.Where(x => x.userId == id).FirstOrDefaultAsync();
            if (user != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsValidUserPassword(int userId, string password)
        {
            var user = await _context.CompanyUsers.Where(x => x.userId == userId && x.password == password).FirstOrDefaultAsync();
            if (user != null)
                return true;
            else
                return false;
        }
        public async Task<bool> UserExistsInCompany(int userId, int companyId)
        {
            var user = await _context.CompanyUsers.Where(x => x.userId == userId && x.companyId == companyId).FirstOrDefaultAsync();
            if (user != null)
                return true;
            else
                return false;
        }
        public async Task<CompanyUsers> Login(string email, string password)
        {
            var user = await _context.CompanyUsers.Include(c=>c.CompanyProfile).Include(r=>r.AccessRole).Where(x => x.email == email && x.password == password).FirstOrDefaultAsync();
            if(user != null)
            {
                return user;
            }
            return new CompanyUsers();
        }
        public async Task ChangePassword(int userId,string oldPassword, string newPassword)
        {
            var user = await _context.CompanyUsers.Where(x => x.userId == userId && x.password == oldPassword).FirstOrDefaultAsync();
            if(user != null)
            {
                user.password = newPassword;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CompanyUsers>> GetAllUsersofCompany(int id)
        {
            return await _context.CompanyUsers.Where(x => x.companyId == id && x.isActive).ToListAsync();
        }

        public async Task AddManyItems(List<CompanyUsers> companyUsers)
        {
            var _companyUsers = new CompanyUsers();
            var _companyUserList = new List<CompanyUsers>();

            foreach (var item in companyUsers.Where(x => x.userId <= 0))
            {
                _companyUsers = await _context.CompanyUsers.FirstOrDefaultAsync(x => x.userId == item.userId);
                if (_companyUsers != null)
                {
                    _companyUsers.password = _encryption.Encrypt(item.password);                        
                }
                _companyUserList.Add(_companyUsers);
            }
            _context.CompanyUsers.AddRange(_companyUserList);

            foreach (var item in companyUsers.Where(x => x.userId > 0))
            {
                _companyUsers = await _context.CompanyUsers.FirstOrDefaultAsync(x => x.userId == item.userId);
                if (_companyUsers != null)
                {
                    _companyUsers.firstName = item.firstName;
                    _companyUsers.lastName = item.lastName;
                    _companyUsers.email = item.email;
                    _companyUsers.roleId = item.roleId;
                    _companyUsers.salutationId = item.salutationId;
                    _companyUsers.about = item.about;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
} 
