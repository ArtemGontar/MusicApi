using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.WebAPI.Infrastructure;
using Music.WebAPI.Models;
using System.Threading.Tasks;

namespace Music.WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }


        // POST api/login
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
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
        public async Task<ActionResult<User>> Register([FromBody]RegisterModel user)
        {
            User usr = new User
            {
                Login = user.Login,
                Password = user.Password,
                Name = user.Name
            };

            await _userService.CreateAsync(usr);

            //SaveChange

            return CreatedAtAction(nameof(Get), new { id = usr.Id }, usr);
        }

        // GET api/songs/5
        [HttpGet("{id:length(24)}")]
        public async Task<User> Get(string id)
        {
            return await Task.FromResult(await _userService.GetAsync(new ObjectId(id)));
        }
    }
}