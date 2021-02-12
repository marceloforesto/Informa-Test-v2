using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InformaTest_WebAPI.Models;

namespace InformaTest_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Track[]> GetAllTracksAsync(bool includeAlbum = false)
        {
            IQueryable<Track> query = _context.Tracks;

            if (includeAlbum)
            {
                query = query.Include(pe => pe.TracksAlbums)
                             .ThenInclude(ad => ad.Album)
                             .ThenInclude(d => d.Artist);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Track> GetTrackAsyncById(int trackId, bool includeAlbum)
        {
            IQueryable<Track> query = _context.Tracks;

            if (includeAlbum)
            {
                query = query.Include(a => a.TracksAlbums)
                             .ThenInclude(ad => ad.Album)
                             .ThenInclude(d => d.Artist);
            }

            query = query.AsNoTracking()
                         .OrderBy(track => track.Id)
                         .Where(track => track.Id == trackId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Track[]> GetTracksAsyncByAlbumId(int albumId, bool includeAlbum)
        {
            IQueryable<Track> query = _context.Tracks;

            if (includeAlbum)
            {
                query = query.Include(p => p.TracksAlbums)
                             .ThenInclude(ad => ad.Album)                             
                             .ThenInclude(d => d.Artist);
            }

            query = query.AsNoTracking()
                         .OrderBy(track => track.Id)
                         .Where(track => track.TracksAlbums.Any(ad => ad.AlbumId == albumId));

            return await query.ToArrayAsync();
        }

        public async Task<Artist[]> GetArtistsAsyncByTrackId(int trackId, bool includeAlbum)
        {
            IQueryable<Artist> query = _context.Artists;

            if (includeAlbum)
            {
                query = query.Include(p => p.Albums);
            }

            query = query.AsNoTracking()
                         .OrderBy(track => track.Id)
                         .Where(track => track.Albums.Any(d => 
                            d.TracksAlbums.Any(ad => ad.TrackId == trackId)));

            return await query.ToArrayAsync();
        }

        public async Task<Artist[]> GetAllArtistsAsync(bool includeAlbums = true)
        {
            IQueryable<Artist> query = _context.Artists;

            if (includeAlbums)
            {
                query = query.Include(c => c.Albums);
            }

            query = query.AsNoTracking()
                         .OrderBy(artist => artist.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Artist> GetArtistAsyncById(int artistId, bool includeAlbums = true)
        {
            IQueryable<Artist> query = _context.Artists;

            if (includeAlbums)
            {
                query = query.Include(pe => pe.Albums);
            }

            query = query.AsNoTracking()
                         .OrderBy(artist => artist.Id)
                         .Where(artist => artist.Id == artistId);

            return await query.FirstOrDefaultAsync();
        }
    }
}