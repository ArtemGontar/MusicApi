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
    /// Artists controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        /// <summary>
        /// Artists controller constructor
        /// </summary>
        /// <param name="artistService"></param>
        public ArtistsController(IArtistService artistService)
        {
            this._artistService = artistService;
        }

        // GET api/artists
        /// <summary>
        /// Get all artists async
        /// </summary>
        /// <returns>Returns IEnumerable artists list</returns>
        [HttpGet]
        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await Task.FromResult(await _artistService.GetAllAsync());
        }

        // GET api/artists/5
        /// <summary>
        /// Get artist by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns artist get by Id</returns>
        [HttpGet("{id:length(24)}")]
        public async Task<Artist> GetAsync(string id)
        {
            return await Task.FromResult(await _artistService.GetAsync(new ObjectId(id)));
        }

        // POST api/artists
        /// <summary>
        /// Create artist async
        /// </summary>
        /// <param name="artist"></param>
        /// <returns>Returns artist that was created</returns>
        [HttpPost]
        public async Task<ActionResult<Artist>> CreateAsync([FromBody]Artist artist)
        {
            await _artistService.CreateAsync(artist);
            
            return CreatedAtAction(nameof(GetAsync), new { id = artist.Id }, artist);
        }

        // PUT api/artists
        /// <summary>
        /// Update artist async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="artist"></param>
        /// <returns>Returns NoContent(204) status code</returns>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Artist artist)
        {
        
            //if (new ObjectId(id) != artist.Id)
            //{
            //    return BadRequest();
            //}
        
            await _artistService.UpdateAsync(new ObjectId(id), artist);
        
            return NoContent();
        }

        // DELETE api/artists
        /// <summary>
        /// Delete artist async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns NoContent(204) status code</returns>
        [HttpDelete]
        public async Task<IActionResult> DeteteAsync(string id)
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