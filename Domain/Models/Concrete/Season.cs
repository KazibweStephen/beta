using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Season
    {
        [Key]
        [Column(Order = 1)]
        public int StartYear { get; set; }

        [Key]
        [Column(Order = 2)]
        public int EndYear { get; set; }

        public ICollection<League> Leagues { get; set; }
    }
}
