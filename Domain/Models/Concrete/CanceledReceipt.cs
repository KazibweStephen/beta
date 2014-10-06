using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class CancelReciept
    {
        [Key]
        [ForeignKey("Receipt")]
        public int RecieptId { get; set; }

        [StringLength(50)]
        public string RecievedFrom { get; set; }

        public string Reason { get; set; }

        public DateTime? CancelationTime { get; set; }

        [StringLength(50)]
        public string ApprovalStatus { get; set; }

        public DateTime? Approvaltime { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        [Required]
        public Receipt Receipt { get; set; }
    }
}
