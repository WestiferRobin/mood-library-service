using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodLibrary.Api.Models
{
    [Table("stations")]
    public class Station
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("genre")]
        public required string Genre { get; set; }
    }
}