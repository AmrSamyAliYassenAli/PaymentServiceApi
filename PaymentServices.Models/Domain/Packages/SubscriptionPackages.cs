using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Packages
{
    [Table(nameof(SubscriptionPackages), Schema = "Packages")]
    public class SubscriptionPackages : Defaults
    {
        [Key]
        public int packageId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        [Required]
        public int noOfUsers { get; set; }

        [Required]
        public int noOfBranches { get; set; }

        public List<SubscriptionPackagePrices> Prices { get; set; }
    }
}
