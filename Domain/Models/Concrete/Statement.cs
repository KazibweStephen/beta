using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Statement
    {
        public int StatementId { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        public string Transcation { get; set; }

        [StringLength(50)]
        public string Method { get; set; }

        [StringLength(50)]
        public string Controller { get; set; }

        public DateTime? StatetmentDate { get; set; }

        [StringLength(255)]
        public string Serial { get; set; }

        public double? BalBefore { get; set; }

        public double? Amount { get; set; }

        public double? BalAfter { get; set; }

        public bool Error { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }
    }
}
