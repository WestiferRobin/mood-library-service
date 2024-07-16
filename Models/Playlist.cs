using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodLibraryApi.Models
{
    [Table("playlists")]
    public class Playlist
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("owner")]
        public Guid Owner { get; set; }
    }
}