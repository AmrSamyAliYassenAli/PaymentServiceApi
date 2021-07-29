using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Security
{
    [Table(nameof(WhitelistIP), Schema = "Security")]
    public class WhitelistIP : Defaults
    {
        [Key]
        public int id { get; set; }

        public string IPAddress { get; set; }

        public string IPType { get; set; }
    }
}
