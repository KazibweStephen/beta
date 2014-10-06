using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal? OpeningCash { get; set; }
        public decimal? ClosingCash { get; set; }
        public string UserId { get; set; }
        public string AssignedBy { get; set; }

        [ForeignKey("Terminal")]
        public int TerminalId { get; set; }

        public Terminal Terminal { get; set; }
    }
}
