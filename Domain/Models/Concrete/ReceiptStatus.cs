using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class ReceiptStatus
    {
        public ReceiptStatus()
        {
            Receipts = new HashSet<Receipt>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusId { get; set; }

        [StringLength(50)]
        public string StatusName { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
