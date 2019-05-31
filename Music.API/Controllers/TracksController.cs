using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.DataAccess.Entities;

namespace Music.API.Controllers
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

        public async Task<ActionResult<IEnumerable<Track>>> Get()
        {
            return Ok(_trackService.GetAll());
        }
    }
}