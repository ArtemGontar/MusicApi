using Microsoft.AspNetCore.Mvc;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Music.WebAPI.Controllers
{
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
        public async Task<ActionResult<IEnumerable<Album>>> GetAll()
        {
            return Ok(_albumService.GetAll());
        }

        // GET api/albums/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Album>> Get(string id)
        {
            return Ok(_albumService.Get(new ObjectId(id)));
        }

        // POST api/albums
        [HttpPost]
        public async Task<ActionResult<Album>> Create([FromBody]Album album)
        {
            _albumService.Create(album);

            //SaveChange

            return CreatedAtAction(nameof(Get), new { id = album.Id }, album);
        }

        // PUT api/albums
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Album album)
        {

            //if (new ObjectId(id) != album.Id)
            //{
            //    return BadRequest();
            //}

            _albumService.Update(new ObjectId(id), album);

            //SaveChange

            return NoContent();
        }

        // DELETE api/albums
        [HttpDelete]
        public async Task<IActionResult> Detete(ObjectId id)
        {
            var album = _albumService.Get(id);

            if (album == null)
            {
                return NotFound();
            }
            _albumService.Delete(id);
            return NoContent();
        }
    }
}