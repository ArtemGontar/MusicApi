using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.DataAccess.Entities;

namespace Music.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            this._trackService = trackService;
        }

        // GET api/tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetAll()
        {
            return Ok(_trackService.GetAll());
        }
    }
}