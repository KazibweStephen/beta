using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Bet
    {
        public Bet()
        {
            GameBetStatus = 0;
            BetOdd = 1;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BetId { get; set; }

        [ForeignKey("Match")]
        public int MatchId { get; set; }

        [ForeignKey("Receipt")]
        public int RecieptId { get; set; }
        public int GameBetStatus { get; set; }

        [ForeignKey("BetOption")]
        public int BetOptionId { get; set; }
        public decimal BetOdd { get; set; }

        public Match Match { get; set; }
        public Receipt Receipt { get; set; }

        public BetOption BetOption { get; set; }

    }
}
