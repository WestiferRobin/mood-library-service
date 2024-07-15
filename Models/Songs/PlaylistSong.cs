using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodLibraryApi.Models
{
    [Table("playlist_songs")]
    public class PlaylistSong
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("playlist_id")]
        public Guid PlaylistId { get; set; }
        [ForeignKey("PlaylistId")]
        public Playlist Playlist { get; set; }

        [Required]
        [Column("song_id")]
        public Guid SongId { get; set; }
        [ForeignKey("SongId")]
        public Song Song { get; set; }
    }
}