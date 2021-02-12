using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InformaTest_WebAPI.Data;
using InformaTest_WebAPI.Models;

namespace InformaTest_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly IRepository _repo;

        public TrackController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllTracksAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{TrackId}")]
        public async Task<IActionResult> GetByTrackId(int TrackId)
        {
            try
            {
                var result = await _repo.GetTrackAsyncById(TrackId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByAlbum/{albumId}")]
        public async Task<IActionResult> GetByAlbumId(int albumId)
        {
            try
            {
                var result = await _repo.GetTracksAsyncByAlbumId(albumId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Track model)
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

        [HttpPut("{trackId}")]
        public async Task<IActionResult> put(int trackId, Track model)
        {
            try
            {
                var track = await _repo.GetTrackAsyncById(trackId, false);
                if(track == null) return NotFound();

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

        [HttpDelete("{trackId}")]
        public async Task<IActionResult> delete(int trackId)
        {
            try
            {
                var track = await _repo.GetTrackAsyncById(trackId, false);
                if(track == null) return NotFound();

                _repo.Delete(track);

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