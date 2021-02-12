using System.Collections.Generic;

namespace InformaTest_WebAPI.Models
{
    public class Album
    {
        public Album() { }
        public Album(int id, string nome, int artistId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ArtistId = artistId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public IEnumerable<TrackAlbum> TracksAlbums { get; set; }
    }
}