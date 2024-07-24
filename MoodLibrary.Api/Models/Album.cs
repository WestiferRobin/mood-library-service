using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodLibrary.Api.Models
{
    [Table("albums")]
    public class Album
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("artist_id")]
        public Guid ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}