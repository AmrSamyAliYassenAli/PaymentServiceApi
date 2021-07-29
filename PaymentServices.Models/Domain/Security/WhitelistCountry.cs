using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Security
{
    [Table(nameof(WhitelistCountry), Schema = "Security")]
    public class WhitelistCountry : Defaults
    {
        [Key]
        public int id { get; set; }

        public int countryId { get; set; }
    }
}
