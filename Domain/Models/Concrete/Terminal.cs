using System.Collections.Generic;

namespace Domain.Models.Concrete
{
    public class Terminal
    {
        public Terminal()
        {
            Shifts = new HashSet<Shift>();
        }

        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
        public ICollection<Shift> Shifts { get; set; }
    }
}
