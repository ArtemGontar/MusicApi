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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            this._artistService = artistService;
        }

        // GET api/artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAll()
        {
            return Ok(await _artistService.GetAllAsync());
        }

        // GET api/artists/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Artist>> Get(string id)
        {
            return Ok(await _artistService.GetAsync(new ObjectId(id)));
        }

        // POST api/artists
        [HttpPost]
        public async Task<ActionResult<Artist>> Create([FromBody]Artist artist)
        {
            await _artistService.CreateAsync(artist);
            
            return CreatedAtAction(nameof(Get), new { id = artist.Id }, artist);
        }

        // PUT api/artists
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Artist artist)
        {
        
            //if (new ObjectId(id) != artist.Id)
            //{
            //    return BadRequest();
            //}
        
            await _artistService.UpdateAsync(new ObjectId(id), artist);
        
            return NoContent();
        }
        
        // DELETE api/artists
        [HttpDelete]
        public async Task<IActionResult> Detete(string id)
        {
            var artist = await _artistService.GetAsync(new ObjectId(id));
        
            if (artist == null)
            {
                return NotFound();
            }
            await _artistService.DeleteAsync(new ObjectId(id));
            return NoContent();
        }
    }
}