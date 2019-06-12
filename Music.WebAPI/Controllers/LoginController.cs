using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.WebAPI.Infrastructure;
using Music.WebAPI.Models;
using System.Threading.Tasks;

namespace Music.WebAPI.Controllers
{
    /// <summary>
    /// Auth controller. For login/register
    /// </summary>
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Auth controller constructor
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="logger"></param>
        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            this._userService = userService;
            _logger = logger;
        }


        // POST api/login
        /// <summary>
        /// User send login and password and method responce token if succeed
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Return token if succeed and returns Unauthorized(401) if failure</returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
            _logger.LogInformation("User try to login");
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

                _logger.LogInformation("User login successful");
                return Ok(token.Value);

            }
            _logger.LogInformation("User login failure");
            return Unauthorized();
        }

        // POST api/register
        /// <summary>
        /// Create new user by ifno from user form fill
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns new user entity</returns>
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

            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = usr.Id }, usr);
        }

        // GET api/songs/5
        /// <summary>
        /// Get user by Id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns user get by Id</returns>
        [HttpGet("{id:length(24)}")]
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await Task.FromResult(await _userService.GetAsync(new ObjectId(id)));
        }
    }
}