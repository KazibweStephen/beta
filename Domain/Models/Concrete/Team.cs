using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Team
    {
        public Team()
        {
            HomeGames = new HashSet<Match>();
            AwayGames = new HashSet<Match>();
            IsNationalTeam = false;
        }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        [ForeignKey("League")]
        public int? LeagueId { get; set; }
        public DateTime? DateRegistered { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public bool IsNationalTeam { get; set; }

        public Country Country { get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<Match> HomeGames { get; set; }

        [InverseProperty("AwayTeam")]
        public ICollection<Match> AwayGames { get; set; }
        public League League { get; set; }
    }
}
