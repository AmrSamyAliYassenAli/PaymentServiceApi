using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain.Security
{
    [Table(nameof(BlockDomain), Schema = "Security")]
    public class BlockDomain : Defaults
    {
        [Key]
        public int id { get; set; }

        public string domain { get; set; }
        [Required]
        public bool blockSubdomain { get; set; }

        public BlockDomain()
        {
            this.blockSubdomain = false;
        }

    }
}
