using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Subscriptions
{
    [Table(nameof(SubscriptionTransaction), Schema = "Subscription")]
    public class SubscriptionTransaction : Defaults
    {
        [Key]
        public int subscriptionTransactionId { get; set; }

        public int companyId { get; set; }

        public int subscriptionId { get; set; }

        public int packagePriceId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public bool isPaid { get; set; }

        public bool isActive { get; set; }

        public SubscriptionTransaction()
        {
            this.isPaid = true;
            this.isActive = true;
        }
    }
}
