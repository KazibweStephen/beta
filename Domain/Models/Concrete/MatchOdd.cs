using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class MatchOdd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameOddId { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        [ForeignKey("BetOption")]
        public int BetOptionId { get; set; }
        public decimal Odd { get; set; }

        public int? HandicapGoals { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public virtual BetOption BetOption { get; set; }
        public Match Game { get; set; }
    }
}
