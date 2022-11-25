using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3_Sis.Models
{
    [Table("Student")]
    public class Studenti
    {
        public int Id { get; set; }
        [Required]
        public string Emri { get; set; }
        [Required]
        public string Mbiemri { get; set; }
        public int KomunaId { get; set; }
        [ForeignKey("KomunaId")]
        public Komuna Komuna { get; set; }

    }
}
