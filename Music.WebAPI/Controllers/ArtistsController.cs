using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> Get(int id)
        {
            return Ok(_artistService.Get(id));
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Artist artist)
        {
        
            if (id != artist.Id)
            {
                return BadRequest();
            }
        
            _artistService.Update(id, artist);
        
            //SaveChange
          
            return NoContent();
        }
        
        // DELETE api/artists
        [HttpDelete]
        public async Task<IActionResult> Detete(int id)
        {
            var artist = _artistService.Get(id);
        
            if (artist == null)
            {
                return NotFound();
            }
            _artistService.Delete(id);
            return NoContent();
        }
    }
}