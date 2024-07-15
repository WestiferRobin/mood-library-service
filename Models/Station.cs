using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodLibraryApi.Models
{
    [Table("stations")]
    public class Station
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("genre")]
        public string Genre { get; set; }
    }
}