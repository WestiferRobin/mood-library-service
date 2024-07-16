using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoodLibraryApi.Models.Songs;

namespace MoodLibraryApi.Models
{
    [Table("artists")]
    public class Artist
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("genre")]
        public required string Genre { get; set; }

        public ICollection<Song> Songs { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}