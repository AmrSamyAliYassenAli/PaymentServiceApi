using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using PaymentServices.Models.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Subscriptions
{
    public class AccessRolesRepository : Repository<AccessRoles>, IAccessRolesRepository
    {
        private readonly MiddlewareDbContext _context;

        public AccessRolesRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }
    }
}
