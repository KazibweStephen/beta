using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Match
    {
        public Match()
        {
            Bets = new HashSet<Bet>();
            AwayScore = 0;
            HomeScore = 0;
            HalfTimeHomeScore = 0;
            HalfTimeAwayScore = 0;
            RegistrationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatchNo { get; set; }
        public string Champ { get; set; }
        public DateTime StartTime { get; set; }
        public string GameStatus { get; set; }
        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HalfTimeHomeScore { get; set; }
        public int HalfTimeAwayScore { get; set; }
        public int? ResultStatus { get; set; }
        [Required]
        public virtual Team AwayTeam { get; set; }
        [Required]
        public virtual Team HomeTeam { get; set; }
        public ICollection<Bet> Bets { get; set; }
        public virtual ICollection<MatchOdd> GameOdds { get; set; }
        public virtual ShortMatchCode ShrtMatchCode { get; set; }
    }
}
