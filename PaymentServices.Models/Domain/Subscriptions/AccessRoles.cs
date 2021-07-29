using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Subscriptions
{
    [Table(nameof(AccessRoles), Schema = "Subscription")]
    public class AccessRoles : Defaults
    {
        [Key]
        public int roleId { get; set; }

        public string name { get; set; }

        public int accessType { get; set; }

        public List<AccessPermissions> permissions { get; set; }
    }
}
