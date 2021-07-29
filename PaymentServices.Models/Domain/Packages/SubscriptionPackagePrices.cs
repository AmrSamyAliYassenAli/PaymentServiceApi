using PaymentServices.Models.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Packages
{
    [Table(nameof(SubscriptionPackagePrices), Schema = "Packages")]

    public class SubscriptionPackagePrices : Defaults
    {
        [Key]
        public int packagePriceId { get; set; }

        public int packageId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }

        public int countryId { get; set; }

        [ForeignKey(nameof(packageId))]
        public SubscriptionPackages Package { get; set; }

        [ForeignKey(nameof(countryId))]
        public Country country { get; set; }

        public bool isMonthly { get; set; }

        public bool isYearly { get; set; }

    }
}
