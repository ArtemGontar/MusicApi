using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this._albumService = albumService;
        }

        // GET api/albums
        [HttpGet]
        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await Task.FromResult(await _albumService.GetAllAsync());
        }

        // GET api/albums/5
        [HttpGet("{id:length(24)}")]
        public async Task<Album> GetAsync(string id)
        {
            return await Task.FromResult(await _albumService.GetAsync(new ObjectId(id)));
        }

        // POST api/albums
        [HttpPost]
        public async Task<ActionResult<Album>> CreateAsync([FromBody]Album album)
        {
            await _albumService.CreateAsync(album);

            //SaveChange

            return CreatedAtAction(nameof(GetAsync), new { id = album.Id }, album);
        }

        // PUT api/albums
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Album album)
        {

            //if (new ObjectId(id) != album.Id)
            //{
            //    return BadRequest();
            //}

            await _albumService.UpdateAsync(new ObjectId(id), album);
            
            return NoContent();
        }

        // DELETE api/albums
        [HttpDelete]
        public async Task<IActionResult> DeteteAsync(ObjectId id)
        {
            var album = await _albumService.GetAsync(id);

            if (album == null)
            {
                return NotFound();
            }
            await _albumService.DeleteAsync(id);
            return NoContent();
        }
    }
}