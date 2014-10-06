using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class BetOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BetOptionId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Option { get; set; }

        public int? HandicapGoals { get; set; }

        [ForeignKey("BetCategory")]
        [Required(ErrorMessage = "* Required")]
        public int BetCategoryId { get; set; }

        public virtual BetCategory BetCategory { get; set; }
    }
}
