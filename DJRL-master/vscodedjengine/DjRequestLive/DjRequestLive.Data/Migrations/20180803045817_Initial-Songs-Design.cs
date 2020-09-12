using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DjRequestLive.Data.Migrations
{
    public partial class InitialSongsDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false),
                    Composer = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: true),
                    Grouping = table.Column<string>(nullable: true),
                    Work = table.Column<string>(nullable: true),
                    MovementNumber = table.Column<string>(nullable: true),
                    MovementCount = table.Column<string>(nullable: true),
                    MovementName = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DiscNumber = table.Column<int>(nullable: true),
                    DiscCount = table.Column<int>(nullable: true),
                    TrackNumber = table.Column<int>(nullable: true),
                    TrackCount = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    BitRate = table.Column<int>(nullable: true),
                    SampleRate = table.Column<int>(nullable: true),
                    VolumeAdjustment = table.Column<int>(nullable: true),
                    Kind = table.Column<string>(nullable: true),
                    Equalizer = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Plays = table.Column<string>(nullable: true),
                    LastPlayed = table.Column<DateTime>(nullable: true),
                    Skips = table.Column<int>(nullable: true),
                    LastSkipped = table.Column<DateTime>(nullable: true),
                    MyRating = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
