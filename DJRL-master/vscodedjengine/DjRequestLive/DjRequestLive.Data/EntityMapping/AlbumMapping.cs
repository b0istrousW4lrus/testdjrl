using DjRequestLive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DjRequestLive.Data.EntityMapping
{
    class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasMany(album => album.Songs)
                .WithOne(song => song.Album);

            builder.HasOne(album => album.Artist)
                .WithMany(artist => artist.Albums);
        }
    }
}
