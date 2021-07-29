using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.Domain
{
    public class Defaults
    {

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime createdAt { get; set; }

        public int createdBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime modifiedAt { get; set; }

        public int modifiedBy { get; set; }

        public bool isDeleted { get; set; }

        public Defaults()
        {
            this.createdAt = DateTime.Now;
            this.modifiedAt = DateTime.Now;
            this.createdBy = -1;
            this.modifiedBy = -1;
            this.isDeleted = false;
        }
    }
}
