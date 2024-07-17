using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodLibrary.Api.Models.Songs
{
    [Table("station_songs")]
    public class StationSong
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("station_id")]
        public Guid StationId { get; set; }
        [ForeignKey("StationId")]
        public required Station Station { get; set; }

        [Required]
        [Column("song_id")]
        public Guid SongId { get; set; }
        [ForeignKey("SongId")]
        public required Song Song { get; set; }
    }
}