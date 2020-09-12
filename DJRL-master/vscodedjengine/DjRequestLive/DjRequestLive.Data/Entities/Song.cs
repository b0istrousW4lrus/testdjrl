using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DjRequestLive.Data.Entities
{
    [Table("Songs")]
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        [Required]
        public Artist Artist { get; set; }
        public string Composer { get; set; }
        public Album Album { get; set; }
        public string Grouping { get; set; }
        public string Work { get; set; }
        public string MovementNumber { get; set; }
        public string MovementCount { get; set; }
        public string MovementName { get; set; }
        public string Genre { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }
        public int? DiscNumber { get; set; }
        public int? DiscCount { get; set; }
        public int? TrackNumber { get; set; }
        public int? TrackCount { get; set; }
        public int? Year { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateAdded { get; set; }
        public int? BitRate { get; set; }
        public int? SampleRate { get; set; }
        public int? VolumeAdjustment { get; set; }
        public string Kind { get; set; }
        public string Equalizer { get; set; }
        public string Comments { get; set; }
        public string Plays { get; set; }
        public DateTime? LastPlayed { get; set; }
        public int? Skips { get; set; }
        public DateTime? LastSkipped { get; set; }
        public string MyRating { get; set; }
        public string Location { get; set; }
    }

}
