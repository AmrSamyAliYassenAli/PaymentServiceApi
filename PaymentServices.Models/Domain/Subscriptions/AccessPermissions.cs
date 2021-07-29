using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Subscriptions
{
    [Table(nameof(AccessPermissions), Schema = "Subscription")]
    public class AccessPermissions : Defaults
    {
        [Key]
        public int permissionId { get; set; }

        [Required]
        public int roleId { get; set; }

        [ForeignKey(nameof(roleId))]
        public AccessRoles role { get; set; }

        public int configId { get; set; }

        public int actionId { get; set; }

        public bool isPolicy { get; set; }

        public bool isAllowed { get; set; }

        public AccessPermissions() 
        { 
            this.isPolicy = false; 
            this.isDeleted = false; 
        }
    }
}
