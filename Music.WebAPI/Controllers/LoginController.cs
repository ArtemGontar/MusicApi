using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.WebAPI.Infrastructure;

namespace Music.WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }


        // POST api/login
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            var usr = await _userService.GetUser(user.Login, user.Password);

            if (usr != null)
            {

                var token = new JwtTokenBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
                    .AddSubject(user.Login)
                    .AddIssuer("issuerTest")
                    .AddAudience("bearerTest")
                    .AddClaim("MembershipId", "111")
                    .AddExpiry(1)
                    .Build();

                return Ok(token.Value);

            }
            return Unauthorized();
        }

        // POST api/register
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            _userService.Create(user);

            //SaveChange

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // GET api/songs/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Song>> Get(string id)
        {
            return Ok(_userService.Get(new ObjectId(id)));
        }
    }
}