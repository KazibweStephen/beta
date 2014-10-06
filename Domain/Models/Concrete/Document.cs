using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Concrete
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentType { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public DateTime DateModified { get; set; }

        [Required]
        [StringLength(20)]
        public string ModifiedBy { get; set; }
    }
}
