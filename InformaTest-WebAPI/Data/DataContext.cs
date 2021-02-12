using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using InformaTest_WebAPI.Models;

namespace InformaTest_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<TrackAlbum> TracksAlbums { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TrackAlbum>()
                .HasKey(AD => new { AD.TrackId, AD.AlbumId });

            builder.Entity<Artist>()
                .HasData(new List<Artist>(){
                    new Artist(1, "Artist1"),
                    new Artist(2, "Artist2"),
                    new Artist(3, "Artist3"),
                    new Artist(4, "Artist4"),
                    new Artist(5, "Artist5"),
                });
            
            builder.Entity<Album>()
                .HasData(new List<Album>{
                    new Album(1, "Album1", 1,"Imagem1"),
                    new Album(2, "Album2", 2,"Imagem2"),
                    new Album(3, "Album3", 3,"Imagem3"),
                    new Album(4, "Album4", 4,"Imagem4"),
                    new Album(5, "Album5", 5,"Imagem5")
                });
            
            builder.Entity<Track>()
                .HasData(new List<Track>(){
                    new Track(1, "Track1", 0, 0, 0),
                    new Track(2, "Track2", 0, 0, 0),
                    new Track(3, "Track3", 0, 0, 0),
                    new Track(4, "Track4", 0, 0, 0),
                    new Track(5, "Track5", 0, 0, 0),
                    new Track(6, "Track6", 0, 0, 0),
                    new Track(7, "Track7", 0, 0, 0)
                });

            builder.Entity<TrackAlbum>()
                .HasData(new List<TrackAlbum>() {
                    new TrackAlbum() {TrackId = 1, AlbumId = 2 },
                    new TrackAlbum() {TrackId = 1, AlbumId = 4 },
                    new TrackAlbum() {TrackId = 1, AlbumId = 5 },
                    new TrackAlbum() {TrackId = 2, AlbumId = 1 },
                    new TrackAlbum() {TrackId = 2, AlbumId = 2 },
                    new TrackAlbum() {TrackId = 2, AlbumId = 5 },
                    new TrackAlbum() {TrackId = 3, AlbumId = 1 },
                    new TrackAlbum() {TrackId = 3, AlbumId = 2 },
                    new TrackAlbum() {TrackId = 3, AlbumId = 3 },
                    new TrackAlbum() {TrackId = 4, AlbumId = 1 },
                    new TrackAlbum() {TrackId = 4, AlbumId = 4 },
                    new TrackAlbum() {TrackId = 4, AlbumId = 5 },
                    new TrackAlbum() {TrackId = 5, AlbumId = 4 },
                    new TrackAlbum() {TrackId = 5, AlbumId = 5 },
                    new TrackAlbum() {TrackId = 6, AlbumId = 1 },
                    new TrackAlbum() {TrackId = 6, AlbumId = 2 },
                    new TrackAlbum() {TrackId = 6, AlbumId = 3 },
                    new TrackAlbum() {TrackId = 6, AlbumId = 4 },
                    new TrackAlbum() {TrackId = 7, AlbumId = 1 },
                    new TrackAlbum() {TrackId = 7, AlbumId = 2 },
                    new TrackAlbum() {TrackId = 7, AlbumId = 3 },
                    new TrackAlbum() {TrackId = 7, AlbumId = 4 },
                    new TrackAlbum() {TrackId = 7, AlbumId = 5 }
                });
        }
    }
}