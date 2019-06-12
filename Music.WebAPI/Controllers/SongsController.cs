using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.WebAPI.Controllers
{
    //[Authorize]
    /// <summary>
    /// Songs controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ISongService _songService;

        /// <summary>
        /// Songs controller constructor
        /// </summary>
        /// <param name="songService"></param>
        public SongsController(ISongService songService)
        {
            this._songService = songService;
        }

        // GET api/songs
        /// <summary>
        /// Get all songs async
        /// </summary>
        /// <returns>Returns IEnumerable songs list</returns>
        [HttpGet]
        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await Task.FromResult(await _songService.GetAllAsync());
        }

        // GET api/songs/5
        /// <summary>
        /// Get song by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns song get by Id</returns>
        [HttpGet("{id:length(24)}")]
        public async Task<Song> GetByIdAsync(string id)
        {
            return await Task.FromResult(await _songService.GetAsync(new ObjectId(id)));
        }

        // POST api/songs
        /// <summary>
        /// Create song async
        /// </summary>
        /// <param name="song"></param>
        /// <returns>Returns song that was created</returns>
        [HttpPost]
        public async Task<ActionResult<Song>> CreateAsync([FromBody] Song song)
        {
            await _songService.CreateAsync(song);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = song.Id }, song);
        }

        // PUT api/songs
        /// <summary>
        /// Update song async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="song"></param>
        /// <returns>Returns NoContent(204) status code</returns>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Song song)
        {
        
            //if (new ObjectId(id) != song.Id)
            //{
            //    return BadRequest();
            //}
        
            await _songService.UpdateAsync(new ObjectId(id), song);
        
            return NoContent();
        }

        // DELETE api/songs
        /// <summary>
        /// Delete song async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns NoContent(204) status code</returns>
        [HttpDelete]
        public async Task<IActionResult> DeteteAsync(string id)
        {
            var song = await _songService.GetAsync(new ObjectId(id));
        
            if (song == null)
            {
                return NotFound();
            }
            await _songService.DeleteAsync(new ObjectId(id));
            return NoContent();
        }
    }
}