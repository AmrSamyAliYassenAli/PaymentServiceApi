using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using PaymentServices.Models.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Subscriptions
{
    public class AccessPermissionsRepository : Repository<AccessPermissions>, IAccessPermissionsRepository
    {
        private readonly MiddlewareDbContext _context;

        public AccessPermissionsRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }
    }
}
