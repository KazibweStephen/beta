using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Branch
    {
        public Branch()
        {
            Receipts = new HashSet<Receipt>();
            Terminals = new HashSet<Terminal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        public int? ManagerId { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("BranchType")]
        public int BranchTypeId { get; set; }

        public BranchType BranchType { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<Terminal> Terminals { get; set; }
    }
}
