using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Concrete
{
    public class Account
    {
        public Account()
        {
         Receipts = new HashSet<Receipt>();
        } 

        [Key]
        [StringLength(50)]
        public string UserId { get; set; }

        public DateTime? DateE { get; set; }

        public double? AmountE { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string AdminE { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
