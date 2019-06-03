using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Implementations;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;

namespace Music.WebAPI.Controllers
{
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
            return Ok(_artistService.GetAll());
        }

        // GET api/artists/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Artist>> Get(string id)
        {
            return Ok(_artistService.Get(new ObjectId(id)));
        }

        // POST api/artists
        [HttpPost]
        public async Task<ActionResult<Artist>> Create([FromBody]Artist artist)
        {
            _artistService.Create(artist);

            //SaveChange

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
        
            _artistService.Update(new ObjectId(id), artist);
        
            //SaveChange
          
            return NoContent();
        }
        
        // DELETE api/artists
        [HttpDelete]
        public async Task<IActionResult> Detete(string id)
        {
            var artist = _artistService.Get(new ObjectId(id));
        
            if (artist == null)
            {
                return NotFound();
            }
            _artistService.Delete(new ObjectId(id));
            return NoContent();
        }
    }
}