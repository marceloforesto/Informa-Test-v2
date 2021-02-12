using System.Threading.Tasks;
using InformaTest_WebAPI.Models;

namespace InformaTest_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Track[]> GetAllTracksAsync(bool includeArtist);        
        Task<Track[]> GetTracksAsyncByAlbumId(int albumId, bool includeAlbum);
        Task<Track> GetTrackAsyncById(int trackId, bool includeArtist);
        
        //PROFESSOR
        Task<Artist[]> GetAllArtistsAsync(bool includeTrack);
        Task<Artist> GetArtistAsyncById(int artistId, bool includeTrack);
        Task<Artist[]> GetArtistsAsyncByTrackId(int trackId, bool includeAlbum);
    }
}