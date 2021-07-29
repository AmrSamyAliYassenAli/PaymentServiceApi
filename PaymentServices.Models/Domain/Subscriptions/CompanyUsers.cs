using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Subscriptions
{
    [Table(nameof(CompanyUsers), Schema = "Subscription")]

    public class CompanyUsers
    {
        [Key]
        public int userId { get; set; }

        [Required]
        public string firstName { get; set; }

        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public int roleId { get; set; }

        [ForeignKey(nameof(roleId))]
        public AccessRoles AccessRole { get; set; }

        [Required]
        public int companyId { get; set; } // This will be the companyid from company profile

        [ForeignKey(nameof(companyId))]
        public CompanyProfile CompanyProfile { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public int salutationId { get; set; }

        public string about { get; set; }

        public bool isActive { get; set; }

        public CompanyUsers()
        {
            this.isActive = false;
        }
    }
}
