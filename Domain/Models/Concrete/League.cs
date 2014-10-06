using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class League
    {
        public League()
        {
            Seasons = new HashSet<Season>();
            Teams = new HashSet<Team>();
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public int? Rating { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public ICollection<Team> Teams { get; set; }
        public Country Country { get; set; }
    }
}
