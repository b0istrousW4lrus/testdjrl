using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DjRequestLive.Data.Entities
{
    [Table("Artists")]
    public class Artist : BaseEntity
    {
        [StringLength(2000)]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }

        public List<Album> Albums { get; set; }
    }
}
