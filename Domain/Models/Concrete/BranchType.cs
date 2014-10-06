using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Concrete
{
    public class BranchType
    {
        public BranchType()
        {
            Branches = new HashSet<Branch>();
        }

        [Key]
        public int BranchTypeId { get; set; }
        public string TypeName { get; set; }

        public ICollection<Branch> Branches { get; set; }
    }
}
