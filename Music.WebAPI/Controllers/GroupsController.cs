using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            this._groupService = groupService;
        }

        // GET api/groups
        [HttpGet]
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await Task.FromResult(await _groupService.GetAllAsync());
        }

        // GET api/groups/5
        [HttpGet("{id:length(24)}")]
        public async Task<Group> GetAsync(string id)
        {
            return await Task.FromResult(await _groupService.GetAsync(new ObjectId(id)));
        }

        // POST api/groups
        [HttpPost]
        public async Task<ActionResult<Group>> CreateAsync([FromBody] Group group)
        {
            await _groupService.CreateAsync(group);
            
            return CreatedAtAction(nameof(GetAsync), new { id = group.Id }, group);
        }

        // PUT api/groups
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Group group)
        {
            //if (new ObjectId(id) != group.Id)
            //{
            //    return BadRequest();
            //}

            await _groupService.UpdateAsync(new ObjectId(id), group);
            
            return NoContent();
        }

        // DELETE api/group
        [HttpDelete]
        public async Task<IActionResult> DeteteAsync(string id)
        {
            var group = await _groupService.GetAsync(new ObjectId(id));

            if (group == null)
            {
                return NotFound();
            }
            await _groupService.DeleteAsync(new ObjectId(id));
            return NoContent();
        }
    }
}