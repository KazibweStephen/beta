using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class ShortMatchCode
    {
        [Key]
        [ForeignKey("Match")]
        public int MatchNo { get; set; }

        public int SetNo { get; set; }

        public int ShortCode { get; set; }

        [Required]
        public Match Match { get; set; }
    }
}
