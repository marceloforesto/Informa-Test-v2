using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InformaTest_WebAPI.Data;
using InformaTest_WebAPI.Models;

namespace InformaTest_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IRepository _repo;

        public ArtistController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllArtistsAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{ArtistId}")]
        public async Task<IActionResult> GetByArtistId(int ArtistId)
        {
            try
            {
                var result = await _repo.GetArtistAsyncById(ArtistId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByTrack/{trackId}")]
        public async Task<IActionResult> GetByTrackId(int trackId)
        {
            try
            {
                var result = await _repo.GetArtistsAsyncByTrackId(trackId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Artist model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> put(int artistId, Artist model)
        {
            try
            {
                var Artist = await _repo.GetArtistAsyncById(artistId, false);
                if(Artist == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> delete(int artistId)
        {
            try
            {
                var Artist = await _repo.GetArtistAsyncById(artistId, false);
                if(Artist == null) return NotFound();

                _repo.Delete(Artist);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}