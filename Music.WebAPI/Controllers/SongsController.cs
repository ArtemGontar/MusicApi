using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;

namespace Music.WebAPI.Controllers
{
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
            return Ok(_songService.GetAll());
        }

        // GET api/songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> Get(string id)
        {
            return Ok(_songService.Get(new ObjectId(id)));
        }

        // POST api/songs
        [HttpPost]
        public async Task<ActionResult<Song>> Create([FromBody] Song song)
        {
            _songService.Create(song);

            //SaveChange

            return CreatedAtAction(nameof(Get), new { id = song.Id }, song);
        }

        // PUT api/songs
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Song song)
        {
        
            if (new ObjectId(id) != song.Id)
            {
                return BadRequest();
            }
        
            _songService.Update(new ObjectId(id), song);
        
            //SaveChange
        
            return NoContent();
        }
        
        // DELETE api/songs
        [HttpDelete]
        public async Task<IActionResult> Detete(string id)
        {
            var song = _songService.Get(new ObjectId(id));
        
            if (song == null)
            {
                return NotFound();
            }
            _songService.Delete(new ObjectId(id));
            return NoContent();
        }
    }
}