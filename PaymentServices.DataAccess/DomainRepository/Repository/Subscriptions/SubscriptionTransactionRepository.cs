using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using PaymentServices.Models.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Subscriptions
{
    public class SubscriptionTransactionRepository : Repository<SubscriptionTransaction>, ISubscriptionTransactionRepository
    {
        private readonly MiddlewareDbContext _context;

        public SubscriptionTransactionRepository(MiddlewareDbContext db) : base(db)
        {
            _context = db;
        }
    }
}
