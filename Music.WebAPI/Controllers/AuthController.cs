using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;
using Music.WebAPI.Infrastructure;

namespace Music.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AuthController : ControllerBase
    //{
    //    private readonly IUserService _authService;

    //    public AuthController(IUserService authService)
    //    {
    //        _authService = authService;
    //    }

    //    // POST api/Auth
    //    [HttpPost]
    //    public async Task<IActionResult> GetToken([FromBody]User user)
    //    {
    //        var usr = await _authService.GetUser(user.Login, user.Password);

    //        if (usr != null)
    //        {

    //            var token = new JwtTokenBuilder()
    //                .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
    //                .AddSubject(user.Login)
    //                .AddIssuer("issuerTest")
    //                .AddAudience("bearerTest")
    //                .AddClaim("MembershipId", "111")
    //                .AddExpiry(1)
    //                .Build();

    //            return Ok(token.Value);

    //        }
    //        else
    //            return Unauthorized();
    //    }
    //}
}