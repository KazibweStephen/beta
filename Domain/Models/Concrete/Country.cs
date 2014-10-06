using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Country
    {
        public Country()
        {
            Teams = new HashSet<Team>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
