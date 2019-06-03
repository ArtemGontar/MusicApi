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
    public class SongsController : ControllerBase
    {
        private ISongService _songService;

        public SongsController(ISongService songService)
        {
            this._songService = songService;
        }

        // GET api/songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAll()
        {
            return Ok(await _songService.GetAllAsync());
        }

        // GET api/songs/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Song>> Get(string id)
        {
            return Ok(await _songService.GetAsync(new ObjectId(id)));
        }

        // POST api/songs
        [HttpPost]
        public async Task<ActionResult<Song>> Create([FromBody] Song song)
        {
            await _songService.CreateAsync(song);

            return CreatedAtAction(nameof(Get), new { id = song.Id }, song);
        }

        // PUT api/songs
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Song song)
        {
        
            //if (new ObjectId(id) != song.Id)
            //{
            //    return BadRequest();
            //}
        
            await _songService.UpdateAsync(new ObjectId(id), song);
        
            return NoContent();
        }
        
        // DELETE api/songs
        [HttpDelete]
        public async Task<IActionResult> Detete(string id)
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