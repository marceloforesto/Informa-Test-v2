namespace InformaTest_WebAPI.Models
{
    public class TrackAlbum
    {
        public TrackAlbum() { }
        public TrackAlbum(int trackId, int albumId)
        {
            this.TrackId = trackId;
            this.AlbumId = albumId;
        }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}