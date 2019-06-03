using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;
using Music.WebAPI.Infrastructure;

namespace Music.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _AuthRepository;

        public AuthController(IAuthRepository AuthRepository)
        {
            _AuthRepository = AuthRepository;
        }

        // POST api/Auth
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            var usr = await _AuthRepository.GetUser(user.Login, user.Password);

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
            else
                return Unauthorized();
        }
    }
}