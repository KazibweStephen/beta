using System;
using System.Collections.Generic;

namespace Domain.Models.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel()
        {
            GameOdds = new List<GameOddViewModel>();
        }
        public int MatchNo { get; set; }
        public int SetNo { get; set; }
        public string Champ { get; set; }
        public DateTime OldDateTime { get; set; }
        public string  StartTime { get; set; }
        public string GameStatus { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HalfTimeHomeScore { get; set; }
        public int HalfTimeAwayScore { get; set; }
        public int? ResultStatus { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeTeamName { get; set; }

        public List<GameOddViewModel> GameOdds { get; set; }
    }

    public class GameOddViewModel
    {
        public string BetCategory { get; set; }
        public int BetOptionId { get; set; }
        public string BetOption { get; set; }
        public decimal Odd { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public int? HandicapGoals { get; set; }
    }
}
