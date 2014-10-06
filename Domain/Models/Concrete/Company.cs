using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Concrete
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyLocation { get; set; }
    }
}
