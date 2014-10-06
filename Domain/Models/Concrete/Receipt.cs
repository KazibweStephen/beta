using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Receipt
    {
        public Receipt()
        {
            GameBets = new HashSet<Bet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceiptId { get; set; }

      //  [ForeignKey("ApplicationUser")]
        [StringLength(128)]
        public string UserId { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public double? Stake { get; set; }
        public double? TotalOdds { get; set; }
        public int ReceiptStatus { get; set; }

        public bool IsCanceled { get; set; }

        public int SetNo { get; set; }
        public int SetSize { get; set; }
        public int SubmitedSize { get; set; }
        public int WonSize { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public ICollection<Bet> GameBets { get; set; }
        public Branch Branch { get; set; }
        public Guid ? Serial{ get; set; }

       // public ApplicationUser ApplicationUser { get; set; }
    }
}
