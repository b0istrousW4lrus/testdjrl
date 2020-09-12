using DjRequestLive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DjRequestLive.Data.EntityMapping
{
    public class ArtistMapping : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasMany(artist => artist.Songs)
                .WithOne(y => y.Artist);

            builder.HasMany(artist => artist.Albums)
                .WithOne(album => album.Artist);
        }
    }
}
