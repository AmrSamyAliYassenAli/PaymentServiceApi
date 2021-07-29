using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Lookups
{
    [Table(nameof(Language), Schema = "Lookup")]
    public class Language : Defaults
    {
        [Key]
        public int languageid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string isoCode { get; set; }
        public bool isActive { get; set; }
    }
}
