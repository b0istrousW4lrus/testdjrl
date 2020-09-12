using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DjRequestLive.Data.Entities
{
    [Table("Albums")]
    public class Album : BaseEntity
    {
        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        [Required]
        public Artist Artist { get; set; }
    }
}
