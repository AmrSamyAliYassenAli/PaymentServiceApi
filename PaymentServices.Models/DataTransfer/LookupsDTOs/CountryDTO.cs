using PaymentServices.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.DataTransfer.LookupsDTOs
{
    public class CountryDTO : Defaults
    {
        [Key]
        [Display(Name = "countryId")]
        public int id { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string isoCode { get; set; }

        public int currencyId { get; set; }

        public bool isDefault { get; set; }

        public int sortOrder { get; set; }

        public bool active { get; set; }
    }
}
