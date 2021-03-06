﻿// <auto-generated />
using System;
using DjRequestLive.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DjRequestLive.Data.Migrations
{
    [DbContext(typeof(DjRequestLiveDbContext))]
    [Migration("20180803045817_Initial-Songs-Design")]
    partial class InitialSongsDesign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DjRequestLive.Data.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("DjRequestLive.Data.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("DjRequestLive.Data.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId");

                    b.Property<int>("ArtistId");

                    b.Property<int?>("BitRate");

                    b.Property<string>("Comments");

                    b.Property<string>("Composer");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateModified");

                    b.Property<int?>("DiscCount");

                    b.Property<int?>("DiscNumber");

                    b.Property<string>("Equalizer");

                    b.Property<string>("Genre");

                    b.Property<string>("Grouping");

                    b.Property<string>("Kind");

                    b.Property<DateTime?>("LastPlayed");

                    b.Property<DateTime?>("LastSkipped");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("MovementCount");

                    b.Property<string>("MovementName");

                    b.Property<string>("MovementNumber");

                    b.Property<string>("MyRating");

                    b.Property<string>("Name");

                    b.Property<string>("Plays");

                    b.Property<int?>("SampleRate");

                    b.Property<string>("Size");

                    b.Property<int?>("Skips");

                    b.Property<string>("Time");

                    b.Property<int?>("TrackCount");

                    b.Property<int?>("TrackNumber");

                    b.Property<int?>("VolumeAdjustment");

                    b.Property<string>("Work");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("DjRequestLive.Data.Entities.Album", b =>
                {
                    b.HasOne("DjRequestLive.Data.Entities.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DjRequestLive.Data.Entities.Song", b =>
                {
                    b.HasOne("DjRequestLive.Data.Entities.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.HasOne("DjRequestLive.Data.Entities.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
